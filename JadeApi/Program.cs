using System.Text.Json.Serialization;
using Auth0.AspNetCore.Authentication;
using JadeApi.Data;
using Microsoft.OpenApi.Models;
using JadeApi.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

const string version = "v0.0.0";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
 options.MinimumSameSitePolicy = SameSiteMode.None;
});
// builder.Services.ConfigureSameSiteNoneCookies();
builder.Services.AddControllers().AddJsonOptions(o => {
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Auth0 configuration
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}",
            ValidateIssuer = true,
            ValidateAudience = false
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                context.Token = accessToken;

                return Task.CompletedTask;
            }
        };

    });

// Azure Sql connection
var connection = builder.Configuration["DB:AzureSqlConnection"]!;
builder.Services.AddDbContext<JadeDbContext>(options =>
    options.UseSqlServer(connection));

// Singletons
builder.Services.AddSingleton(new CosmosClient(builder.Configuration["DB:CosmosDbConnection"]!));

// Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jade note taking swagger", Version = version, Description = "Refer to github for docs: https://github.com/jade-note-taking/api"});
    c.AddSignalRSwaggerGen();

    // TODO: oauth2 from swagger docs, add later
    // c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    // {
    //     Type = SecuritySchemeType.OAuth2,
    //     Flows = new OpenApiOAuthFlows
    //     {
    //         Implicit = new OpenApiOAuthFlow
    //         {
    //             AuthorizationUrl = new Uri("/auth/connect", UriKind.Relative),
    //             Scopes = new Dictionary<string, string>
    //             {
    //                 { "readAccess", "Access read operations" },
    //                 { "writeAccess", "Access write operations" }
    //             }
    //         }
    //     }
    // });
    //
    // c.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     {
    //         new OpenApiSecurityScheme
    //         {
    //             Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
    //         },
    //         new[] { "readAccess", "writeAccess" }
    //     }
    // });
});

var app = builder.Build();

// Auth0
app.UseAuthentication();
app.UseAuthorization();

// Route mapping
app.MapHub<NotesHub>("/Hub/Note");
app.MapHub<FoldersHub>("/Hub/Folder");
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

// Running app
app.Run();

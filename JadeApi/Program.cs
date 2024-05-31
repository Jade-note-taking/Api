using System.Text.Json.Serialization;
using Auth0.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

const string version = "v0.0.0";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
 options.MinimumSameSitePolicy = SameSiteMode.None;
});
// builder.Services.ConfigureSameSiteNoneCookies();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

builder.Services.AddControllers().AddJsonOptions(o => {
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jade note taking swagger", Version = version, Description = "Refer to github for docs: https://github.com/jade-note-taking/api"});

    // NOTE: oauth2 from swagger docs, add later
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

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

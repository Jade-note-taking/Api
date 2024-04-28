using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

const string version = "v0.0.0";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions(o => {
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jade note taking swagger", Version = version, Description = "Refer to github for docs: https://github.com/jade-note-taking/api"});

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("/auth/connect", UriKind.Relative),
                Scopes = new Dictionary<string, string>
                {
                    { "readAccess", "Access read operations" },
                    { "writeAccess", "Access write operations" }
                }
            }
        }
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            },
            new[] { "readAccess", "writeAccess" }
        }
    });
});

var app = builder.Build();
app.UseHttpsRedirection(); // Auto redirecting over to https
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseSwaggerUI(c =>
// {
//     c.OAuthClientId("test-id");
//     c.OAuthClientSecret("test-secret");
//     c.OAuthRealm("test-realm");
//     c.OAuthAppName("test-app");
//     c.OAuthScopeSeparator(" ");
//     c.OAuthAdditionalQueryStringParams(new Dictionary<string, string> { { "foo", "bar" }});
//     c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
// });

app.Run();

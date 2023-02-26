using System.Reflection;
using CleanCQRS.Domain.Options;
using Microsoft.OpenApi.Models;

namespace CleanCQRS.API.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwaggerCore(this IServiceCollection services, AppOptions coreAppOptions,
        AuthOptions coreAuthOptions)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = $"{coreAppOptions.AppName} API",
                Version = coreAppOptions.AppVersion,
                Description = coreAppOptions.AppDescription,
                Contact = new OpenApiContact
                    { Name = coreAppOptions.AppAuthor, Url = new Uri(coreAppOptions.AppAuthorUrl) },
                License = new OpenApiLicense
                {
                    Name = coreAppOptions.AppLicense,
                    Url = new Uri(coreAppOptions.AppLicenseUrl)
                }
            });

            options.AddSecurityDefinition("OpenId", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OpenIdConnect,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "Bearer",
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(coreAuthOptions.AuthServerUrl,
                            $"realms/{coreAuthOptions.Realm}/protocol/openid-connect/auth"),
                        TokenUrl = new Uri(coreAuthOptions.AuthServerUrl,
                            $"realms/{coreAuthOptions.Realm}/protocol/openid-connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            {
                                "openid", "openid"
                            },
                            {
                                "api", "api"
                            },
                        },
                    },
                },
                OpenIdConnectUrl = new Uri(coreAuthOptions.AuthServerUrl,
                    $"realms/{coreAuthOptions.Realm}/.well-known/openid-configuration"),
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "OpenId",
                        },
                    },
                    new List<string> { "openid", "profile", "email", "offline_access", "roles" }
                },
            });

            var filePath = Path.Combine(AppContext.BaseDirectory,
                Assembly.GetAssembly(typeof(Program)).GetName().Name + ".xml");
            options.IncludeXmlComments(filePath);
        });

        return services;
    }
}
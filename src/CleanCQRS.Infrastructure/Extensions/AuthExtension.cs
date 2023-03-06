using CleanCQRS.Domain.Constants;
using CleanCQRS.Domain.Options;
using CleanCQRS.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CleanCQRS.Infrastructure.Extensions;

public static class AuthExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services, AuthOptions authOptions)
    {
        services.AddTransient<IClaimsTransformation, KeycloakClaimsTransformation>();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.MetadataAddress =
                $"{authOptions.AuthServerUrl}realms/{authOptions.Realm}/.well-known/openid-configuration";
            x.RequireHttpsMetadata = false; // only for dev
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,

                ValidIssuer = $"{authOptions.AuthServerUrl}realms/{authOptions.Realm}",
                ValidateAudience = true,
                ValidAudience = "account",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            };
        });

        services.AddAuthorization(o =>
        {
            o.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("email_verified", "true")
                .Build();

            o.AddPolicy(AuthPolicy.IsAdmin,
                policy => { policy.RequireAssertion(context => context.User.IsInRole(AuthRole.Admin)); });
        });

        return services;
    }
}
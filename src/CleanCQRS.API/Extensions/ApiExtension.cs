using CleanCQRS.API.Middlewares;
using CleanCQRS.Domain.Options;

namespace CleanCQRS.API.Extensions;

public static class ApiExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppOptions>(configuration.GetSection(AppOptions.App));
        services.Configure<AuthOptions>(configuration.GetSection(AuthOptions.Auth));
        var appOptions = configuration.GetSection(AppOptions.App).Get<AppOptions>();
        var authOptions = configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
        services.AddHealthChecks();
        services.AddSwaggerCore(appOptions, authOptions);
        services.AddScoped<ExceptionMiddleware>();
        services.AddScoped<LoggerMiddleware>();

        return services;
    }

    public static WebApplication UseApi(this WebApplication app)
    {
        var authOptions = app.Configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.OAuthClientId(authOptions?.SwaggerClientId);
            options.OAuthClientSecret(authOptions?.SwaggerClientSecret);
            options.OAuthScopes("profile", "openid", "email", "roles");
            options.OAuthUsePkce();
            options.EnablePersistAuthorization();
        });

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseMiddleware<LoggerMiddleware>();

        if (app.Environment.IsProduction())
        {
            app.UseHttpsRedirection();
        }

        app.UseStaticFiles();

        app.UseCors("AllowAll");

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.MapHealthChecks("/health");

        return app;
    }
}
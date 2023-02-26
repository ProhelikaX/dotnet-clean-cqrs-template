using CleanCQRS.Domain.Constants;
using CleanCQRS.Domain.Options;
using CleanCQRS.Domain.UnitOfWorks;
using CleanCQRS.Infrastructure.Data;
using CleanCQRS.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CleanCQRS.Infrastructure.Extensions;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration, IHostEnvironment environment)
    {
        services.Configure<AuthOptions>(configuration.GetSection(AuthOptions.Auth));
        var authOptions = configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

        if (authOptions != null) services.AddAuth(authOptions);

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            if (environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();

                options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));

                options.UseSqlite(configuration.GetConnectionString(Key.DefaultConnection),
                    builder => { builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName); });
            }
            else
            {
                options.UseNpgsql(Environment.GetEnvironmentVariable(Key.DbConnectionString),
                    builder =>
                    {
                        builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        builder.EnableRetryOnFailure();
                    });
            }
        });


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
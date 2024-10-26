using LibraryMS.Services.Auth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Auth.Infrastructure.Configurations;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AuthDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        return services;
    }
}
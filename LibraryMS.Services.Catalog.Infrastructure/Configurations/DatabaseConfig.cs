using LibraryMS.Services.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Catalog.Infrastructure.Configurations;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<CatalogDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        return services;
    }
}
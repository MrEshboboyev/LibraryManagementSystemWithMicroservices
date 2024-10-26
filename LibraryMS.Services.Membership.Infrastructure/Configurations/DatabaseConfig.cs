using LibraryMS.Services.Membership.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Membership.Infrastructure.Configurations;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<MembershipDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        return services;
    }
}
using LibraryMS.Services.Loan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Loan.Infrastructure.Configurations;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<LoanDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        return services;
    }
}
using LibraryMS.Services.Loan.Application.Common.Interfaces;
using LibraryMS.Services.Loan.Application.Services;
using LibraryMS.Services.Loan.Infrastructure.Implementations;
using LibraryMS.Services.Loan.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Loan.Infrastructure.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // adding lifetimes
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBookLoanService, BookLoanService>();
        services.AddScoped<IFineService, FineService>();

        return services;
    }
}

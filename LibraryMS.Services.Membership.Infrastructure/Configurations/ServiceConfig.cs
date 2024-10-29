using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Application.Services;
using LibraryMS.Services.Membership.Infrastructure.Implementations;
using LibraryMS.Services.Membership.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Membership.Infrastructure.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // adding lifetimes
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IMembershipTypeService, MembershipTypeService>();

        return services;
    }
}

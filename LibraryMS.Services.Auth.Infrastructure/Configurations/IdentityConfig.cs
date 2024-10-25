using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using LibraryMS.Services.Auth.Domain.Entities;
using LibraryMS.Services.Auth.Infrastructure.Data;

namespace LibraryMS.Services.Auth.Infrastructure.Configurations;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // User will be locked out for 5 minutes
            options.Lockout.MaxFailedAccessAttempts = 5; // Lockout occurs after 5 failed attempts
            options.Lockout.AllowedForNewUsers = true;   // Lockout enabled for new users
        })
        .AddEntityFrameworkStores<AuthDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }
}
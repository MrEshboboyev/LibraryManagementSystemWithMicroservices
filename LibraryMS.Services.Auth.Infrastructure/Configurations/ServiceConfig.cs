using Microsoft.Extensions.DependencyInjection;
using LibraryMS.Services.Auth.Application.Services;
using LibraryMS.Services.Auth.Infrastructure.Implementations;
using LibraryMS.Services.Auth.Application.Common.Interfaces;
using LibraryMS.Services.Auth.Infrastructure.Data;

namespace LibraryMS.Services.Auth.Infrastructure.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // adding lifetimes
        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IUserProfileService, UserProfileService>();
        //services.AddScoped<INotificationService, NotificationService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IFileService, FileService>();

        return services;
    }
}

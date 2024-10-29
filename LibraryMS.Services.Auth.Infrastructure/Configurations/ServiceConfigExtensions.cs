using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibraryMS.Services.Auth.Infrastructure.ExternalClients;
using LibraryMS.Services.Auth.Application.Common.Interfaces.External;

namespace LibraryMS.Services.Auth.Infrastructure.Configurations;

public static class ServiceConfigExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Add MembershipServiceClient with HttpClient configuration
        services.AddHttpClient<IMembershipServiceClient, MembershipServiceClient>(client =>
        {
            client.BaseAddress = new Uri(configuration["ServiceUrls:MembershipAPI"]
                    ?? throw new InvalidOperationException("MembershipAPI URL is missing."));
        });

        return services;
    }
}

using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Application.Services;
using LibraryMS.Services.Catalog.Infrastructure.Implementations;
using LibraryMS.Services.Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMS.Services.Catalog.Infrastructure.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // adding lifetimes
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPublisherService, PublisherService>();

        return services;
    }
}

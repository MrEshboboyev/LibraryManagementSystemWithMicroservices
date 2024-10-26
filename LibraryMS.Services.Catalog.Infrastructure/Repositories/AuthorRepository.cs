using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Domain.Entities;
using LibraryMS.Services.Catalog.Infrastructure.Data;

namespace LibraryMS.Services.Catalog.Infrastructure.Repositories;

public class AuthorRepository(CatalogDbContext db) : Repository<Author>(db),
    IAuthorRepository
{
}


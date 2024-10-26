using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Infrastructure.Data;

namespace LibraryMS.Services.Catalog.Infrastructure.Repositories
{
    public class UnitOfWork(CatalogDbContext db) : IUnitOfWork
    {
        private readonly CatalogDbContext _db = db;

        public IAuthorRepository Author { get; private set; } = new AuthorRepository(db);
        public IBookRepository Book { get; private set; } = new BookRepository(db);
        public ICategoryRepository Category { get; private set; } = new CategoryRepository(db);
        public IPublisherRepository Publisher { get; private set; } = new PublisherRepository(db);

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

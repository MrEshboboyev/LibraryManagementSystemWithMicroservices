namespace LibraryMS.Services.Catalog.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IAuthorRepository Author { get; }
    IBookRepository Book { get; }
    ICategoryRepository Category { get; }
    IPublisherRepository Publisher { get; }
    
    Task SaveAsync();
}

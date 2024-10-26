using LibraryMS.Services.Catalog.Application.DTOs;

namespace LibraryMS.Services.Catalog.Application.Services;

public interface IBookService
{
    // Retrieves all books
    Task<IEnumerable<BookDTO>> GetAllBooksAsync();

    // Retrieves a book by its unique ID
    Task<BookDTO?> GetBookByIdAsync(Guid bookId);

    // Adds a new book to the catalog
    Task<BookDTO> AddBookAsync(BookDTO bookDTO);

    // Updates an existing book's information
    Task<bool> UpdateBookAsync(BookDTO bookDTO);

    // Deletes a book by its ID
    Task<bool> DeleteBookAsync(Guid bookId);

    // Searches books by title (partial match)
    Task<IEnumerable<BookDTO>> SearchBooksByTitleAsync(string title);

    // Retrieves books by author
    Task<IEnumerable<BookDTO>> GetBooksByAuthorAsync(Guid authorId);

    // Retrieves books by category
    Task<IEnumerable<BookDTO>> GetBooksByCategoryAsync(Guid categoryId);

    // Retrieves books by publisher
    Task<IEnumerable<BookDTO>> GetBooksByPublisherAsync(Guid publisherId);
}
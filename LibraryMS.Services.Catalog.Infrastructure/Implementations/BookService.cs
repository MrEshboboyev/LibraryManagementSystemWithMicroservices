using AutoMapper;
using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using LibraryMS.Services.Catalog.Domain.Entities;

namespace LibraryMS.Services.Catalog.Infrastructure.Implementations;

public class BookService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IBookService
{
    // Retrieves all books
    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
    {
        var allBooks = await _unitOfWork.Book.GetAllAsync(
            includeProperties: "Author,Category,Publisher");

        var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(allBooks);

        return mappedBooks;
    }

    // Retrieves a book by its unique ID
    public async Task<BookDTO?> GetBookByIdAsync(Guid bookId)
    {
        var book = await _unitOfWork.Book.GetAsync(
            filter: m => m.Id == bookId,
            includeProperties: "Author,Category,Publisher")
            ?? throw new Exception("Book not found!");

        var mappedBook = _mapper.Map<BookDTO>(book);

        return mappedBook;
    }

    // Adds a new book to the catalog
    public async Task<BookDTO> AddBookAsync(BookDTO bookDTO)
    {
        var bookForDb = _mapper.Map<Book>(bookDTO);

        await _unitOfWork.Book.AddAsync(bookForDb);
        await _unitOfWork.SaveAsync();

        // mapping db fields
        _mapper.Map(bookForDb, bookDTO);

        return bookDTO;
    }

    // Updates an existing book's information
    public async Task<bool> UpdateBookAsync(BookDTO bookDTO)
    {
        var bookFromDb = await _unitOfWork.Book.GetAsync(m => m.Id == bookDTO.Id)
            ?? throw new Exception("Book not found!");

        // mapping fields
        _mapper.Map(bookDTO, bookFromDb);

        await _unitOfWork.Book.UpdateAsync(bookFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes a book by its ID
    public async Task<bool> DeleteBookAsync(Guid bookId)
    {
        var bookFromDb = await _unitOfWork.Book.GetAsync(m => m.Id == bookId)
            ?? throw new Exception("Book not found!");

        await _unitOfWork.Book.RemoveAsync(bookFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Searches books by title (partial match)
    public async Task<IEnumerable<BookDTO>> SearchBooksByTitleAsync(string title)
    {
        var searchedBooks = await _unitOfWork.Book.GetAllAsync(
            filter: b => b.Title.Contains(title),
            includeProperties: "Author,Category,Publisher");

        var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(searchedBooks);

        return mappedBooks;
    }

    // Retrieves books by author
    public async Task<IEnumerable<BookDTO>> GetBooksByAuthorAsync(Guid authorId)
    {
        var authorBooks = await _unitOfWork.Book.GetAllAsync(
            filter: b => b.AuthorId == authorId,
            includeProperties: "Author,Category,Publisher");

        var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(authorBooks);

        return mappedBooks;
    }

    // Retrieves books by category
    public async Task<IEnumerable<BookDTO>> GetBooksByCategoryAsync(Guid categoryId)
    {
        var categoryBooks = await _unitOfWork.Book.GetAllAsync(
            filter: b => b.CategoryId == categoryId,
            includeProperties: "Author,Category,Publisher");

        var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(categoryBooks);

        return mappedBooks;
    }

    // Retrieves books by publisher
    public async Task<IEnumerable<BookDTO>> GetBooksByPublisherAsync(Guid publisherId)
    {
        var publisherBooks = await _unitOfWork.Book.GetAllAsync(
            filter: b => b.AuthorId == publisherId,
            includeProperties: "Author,Category,Publisher");

        var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(publisherBooks);

        return mappedBooks;
    }
}
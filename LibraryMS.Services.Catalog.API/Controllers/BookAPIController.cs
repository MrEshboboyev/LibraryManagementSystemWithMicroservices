using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Catalog.API.Controllers;

[Route("api/books")]
[ApiController]
public class BookAPIController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;
    private ResponseDTO _response = new();

    // POST
    // /api/books
    // Add a new book
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] BookDTO bookDTO)
    {
        try
        {
            var result = await _bookService.AddBookAsync(bookDTO);
            _response.Result = result;
        }
        catch (Exception ex) 
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/books
    // Get all books (supports pagination and filtering)
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _bookService.GetAllBooksAsync();
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/books/{id}
    // Get details of a specific book by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _bookService.GetBookByIdAsync(id);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // PUT
    // /api/books/{id}
    // Update a book’s information
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] BookDTO bookDTO)
    {
        try
        {
            var result = await _bookService.UpdateBookAsync(bookDTO);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // DELETE
    // /api/books/{id}
    // Delete a book by ID
    [HttpDelete("{id:guid}")]
    public async Task<ResponseDTO> Delete(Guid id)
    {
        try
        {
            var result = await _bookService.DeleteBookAsync(id);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/books/search
    // Search books by title
    [HttpGet("search")]
    public async Task<ResponseDTO> SearchByTitle(string title)
    {
        try
        {
            var result = await _bookService.SearchBooksByTitleAsync(title);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }


    // GET
    // /api/books/author/{authorId}
    // Get books by author ID
    [HttpGet("author/{authorId:guid}")]
    public async Task<ResponseDTO> GetByAuthor(Guid authorId)
    {
        try
        {
            var result = await _bookService.GetBooksByAuthorAsync(authorId);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/books/category/{categoryId}
    // Get books by category ID
    [HttpGet("category/{categoryId:guid}")]
    public async Task<ResponseDTO> GetByCategory(Guid categoryId)
    {
        try
        {
            var result = await _bookService.GetBooksByCategoryAsync(categoryId);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/books/publisher/{publisherId}
    // Get books by publisher ID
    [HttpGet("publisher/{publisherId:guid}")]
    public async Task<ResponseDTO> GetByPublisher(Guid publisherId)
    {
        try
        {
            var result = await _bookService.GetBooksByPublisherAsync(publisherId);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
}


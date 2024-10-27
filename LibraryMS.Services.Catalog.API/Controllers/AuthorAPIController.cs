using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Catalog.API.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorAPIController(IAuthorService authorService) : ControllerBase
{
    private readonly IAuthorService _authorService = authorService;
    private ResponseDTO _response = new();

    // POST
    // /api/authors
    // Add a new author
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] AuthorDTO authorDTO)
    {
        try
        {
            var result = await _authorService.AddAuthorAsync(authorDTO);
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
    // /api/authors
    // Get all authors (with pagination support)
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _authorService.GetAllAuthorsAsync();
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
    // /api/authors/{id}
    // Get details of a specific author by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _authorService.GetAuthorByIdAsync(id);
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
    // /api/authors
    // Update an author’s information
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] AuthorDTO authorDTO)
    {
        try
        {
            var result = await _authorService.UpdateAuthorAsync(authorDTO);
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


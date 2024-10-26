using LibraryMS.Services.Catalog.Application.DTOs;

namespace LibraryMS.Services.Catalog.Application.Services;

public interface IAuthorService
{
    // Retrieves all authors
    Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();

    // Retrieves an author by their unique ID
    Task<AuthorDTO?> GetAuthorByIdAsync(Guid authorId);

    // Adds a new author to the catalog
    Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDTO);

    // Updates an existing author's information
    Task<bool> UpdateAuthorAsync(AuthorDTO authorDTO);

    // Deletes an author by their ID
    Task<bool> DeleteAuthorAsync(Guid authorId);
}
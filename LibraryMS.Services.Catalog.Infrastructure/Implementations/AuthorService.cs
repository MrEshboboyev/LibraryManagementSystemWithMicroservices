using AutoMapper;
using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using LibraryMS.Services.Catalog.Domain.Entities;

namespace LibraryMS.Services.Catalog.Infrastructure.Implementations;

public class AuthorService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IAuthorService
{
    // Retrieves all authors
    public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
    {
        var allAuthors = await _unitOfWork.Author.GetAllAsync(
            includeProperties: "Books");

        var mappedAuthors = _mapper.Map<IEnumerable<AuthorDTO>>(allAuthors);

        return mappedAuthors;
    }

    // Retrieves a author by its unique ID
    public async Task<AuthorDTO?> GetAuthorByIdAsync(Guid authorId)
    {
        var author = await _unitOfWork.Author.GetAsync(
            filter: a => a.Id == authorId,
            includeProperties: "Books");

        var mappedAuthor = _mapper.Map<AuthorDTO>(author);

        return mappedAuthor;
    }

    // Adds a new author to the catalog
    public async Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDTO)
    {
        var authorForDB = _mapper.Map<Author>(authorDTO);

        await _unitOfWork.Author.AddAsync(authorForDB);
        await _unitOfWork.SaveAsync();

        _mapper.Map(authorForDB, authorDTO);

        return authorDTO;
    }

    // Updates an existing author's information
    public async Task<bool> UpdateAuthorAsync(AuthorDTO authorDTO)
    {
        var authorFromDB = await _unitOfWork.Author.GetAsync(a => a.Id == authorDTO.Id)
            ?? throw new Exception("Author not found!");

        // mapping fields
        _mapper.Map(authorDTO, authorFromDB);

        await _unitOfWork.Author.UpdateAsync(authorFromDB);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes an author by their ID
    public async Task<bool> DeleteAuthorAsync(Guid authorId)
    {
        var authorFromDB = await _unitOfWork.Author.GetAsync(a => a.Id == authorId)
            ?? throw new Exception("Author not found!");

        await _unitOfWork.Author.RemoveAsync(authorFromDB);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
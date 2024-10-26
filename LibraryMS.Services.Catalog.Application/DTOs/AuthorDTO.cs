namespace LibraryMS.Services.Catalog.Application.DTOs;

public class AuthorDTO
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Biography { get; set; }

    // Navigation property to books
    public ICollection<BookDTO> BookDTOs { get; set; } = [];
}
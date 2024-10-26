namespace LibraryMS.Services.Catalog.Application.DTOs;

public class CategoryDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }  
    public string? Description { get; set; }
    public ICollection<BookDTO> BookDTOs { get; set; } = [];
}
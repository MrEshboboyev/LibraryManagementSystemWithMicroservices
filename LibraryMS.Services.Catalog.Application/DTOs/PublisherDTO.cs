namespace LibraryMS.Services.Catalog.Application.DTOs;

public class PublisherDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
    public ICollection<BookDTO> BookDTOs { get; set; } = [];
}
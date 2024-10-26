namespace LibraryMS.Services.Catalog.Application.DTOs;

public class BookDTO
{
    public Guid Id { get; set; }
    public required string Title { get; set; }  
    public string? ISBN { get; set; }  
    public DateTime PublicationDate { get; set; }
    public Guid AuthorId { get; set; }
    public required AuthorDTO AuthorDTO { get; set; }
    public Guid CategoryId { get; set; }
    public required CategoryDTO CategoryDTO { get; set; }
    public Guid PublisherId { get; set; }
    public required PublisherDTO PublisherDTO { get; set; }
    public bool IsAvailable { get; set; } = true; 
}
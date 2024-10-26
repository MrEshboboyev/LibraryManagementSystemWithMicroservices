namespace LibraryMS.Services.Catalog.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }  // Title of the book
    public string? ISBN { get; set; }  // ISBN for unique identification
    public DateTime PublicationDate { get; set; }

    // Foreign key and navigation for author
    public Guid AuthorId { get; set; }
    public required Author Author { get; set; }

    // Foreign key and navigation for category
    public Guid CategoryId { get; set; }
    public required Category Category { get; set; }

    // Foreign key and navigation for publisher
    public Guid PublisherId { get; set; }
    public required Publisher Publisher { get; set; }

    public bool IsAvailable { get; set; } = true;  // Indicates if the book is available for loan
}

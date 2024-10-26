namespace LibraryMS.Services.Catalog.Domain.Entities;

public class Publisher
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }

    // Navigation property to books
    public ICollection<Book> Books { get; set; } = [];
}

namespace LibraryMS.Services.Catalog.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }  // e.g., Fiction, Science, History
    public string? Description { get; set; }

    // Navigation property to books
    public ICollection<Book> Books { get; set; } = [];
}

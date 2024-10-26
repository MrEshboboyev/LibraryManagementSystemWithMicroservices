namespace LibraryMS.Services.Catalog.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Biography { get; set; }

    // Navigation property to books
    public ICollection<Book> Books { get; set; } = [];
}

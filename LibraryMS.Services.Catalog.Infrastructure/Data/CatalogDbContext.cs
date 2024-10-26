using LibraryMS.Services.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Services.Catalog.Infrastructure.Data;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Author - Book relationship
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents deletion of an Author if they have Books

        // Configure Category - Book relationship
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Books)
            .WithOne(b => b.Category)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents deletion of a Category if it has Books

        // Configure Publisher - Book relationship
        modelBuilder.Entity<Publisher>()
            .HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents deletion of a Publisher if it has Books

        // Configure Book properties
        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Book>()
            .Property(b => b.ISBN)
            .HasMaxLength(20); // Optional, but helpful for data consistency

        modelBuilder.Entity<Book>()
            .Property(b => b.PublicationDate)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Store as 'date' if PostgreSQL supports this type
    }
}


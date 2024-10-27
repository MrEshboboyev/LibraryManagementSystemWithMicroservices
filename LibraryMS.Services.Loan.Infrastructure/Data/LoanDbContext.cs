using LibraryMS.Services.Loan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Services.Loan.Infrastructure.Data;

public class LoanDbContext(DbContextOptions<LoanDbContext> options) : DbContext(options)
{
    public DbSet<Fine> Fines { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure BookLoan - Fine relationship
        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Fine)
            .WithOne(f => f.Loan)
            .HasForeignKey<Fine>(f => f.LoanId)
            .OnDelete(DeleteBehavior.Cascade); // Deletes Fine if BookLoan is deleted

        // Configure BookLoan properties
        modelBuilder.Entity<BookLoan>()
            .Property(bl => bl.BorrowedDate)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Adjust to "timestamp" for PostgreSQL

        modelBuilder.Entity<BookLoan>()
            .Property(bl => bl.DueDate)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<BookLoan>()
            .Property(bl => bl.ReturnedDate)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false);

        // Configure Fine properties
        modelBuilder.Entity<Fine>()
            .Property(f => f.Amount)
            .HasColumnType("decimal(18,2)"); // Define precision for Amount field if needed

        modelBuilder.Entity<Fine>()
            .Property(f => f.IssuedDate)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Fine>()
            .Property(f => f.Reason)
            .HasMaxLength(100); // Set a reasonable limit for the Reason field
    }
}


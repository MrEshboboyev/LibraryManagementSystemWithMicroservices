using LibraryMS.Services.Loan.Domain.Enums;

namespace LibraryMS.Services.Loan.Domain.Entities;

public class BookLoan
{
    public Guid Id { get; set; }

    // Foreign key for Member (from Membership Service)
    public Guid MemberId { get; set; }

    // Foreign key for Book (from Catalog Service)
    public Guid BookId { get; set; }

    public DateTime BorrowedDate { get; set; }       // Date when the book was borrowed
    public DateTime DueDate { get; set; }            // Date when the book is due to be returned
    public DateTime? ReturnedDate { get; set; }      // Date when the book was actually returned

    public BookLoanStatus Status { get; set; } = BookLoanStatus.Active; // Loan status (e.g., Active, Completed, Overdue)

    // Navigation to optional fine if book is overdue
    public Fine? Fine { get; set; }
}

namespace LibraryMS.Services.Loan.Domain.Entities;

public class Fine
{
    public Guid Id { get; set; }

    // Foreign key to Loan
    public Guid LoanId { get; set; }

    public decimal Amount { get; set; }               // Amount of the fine
    public DateTime IssuedDate { get; set; }          // Date the fine was issued
    public bool IsPaid { get; set; } = false;         // Payment status

    public string Reason { get; set; } = "Overdue";   // Reason for the fine (e.g., "Overdue")
    public BookLoan? BookLoan { get; set; }
}

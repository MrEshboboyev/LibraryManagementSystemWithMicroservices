namespace LibraryMS.Services.Loan.Domain.Enums;

public enum BookLoanStatus
{
    Active,     // Loan is active and book is currently borrowed
    Completed,  // Loan is completed, book has been returned
    Overdue     // Loan is overdue and book is not yet returned
}

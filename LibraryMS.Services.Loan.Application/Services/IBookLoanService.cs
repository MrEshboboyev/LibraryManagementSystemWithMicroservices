using LibraryMS.Services.Loan.Application.DTOs;

namespace LibraryMS.Services.Loan.Application.Services;

public interface IBookLoanService
{
    // Retrieves all book loans
    Task<IEnumerable<BookLoanDTO>> GetAllBookLoansAsync();

    // Retrieves a specific book loan by its ID
    Task<BookLoanDTO?> GetBookLoanByIdAsync(Guid loanId);

    // Creates a new book loan record
    Task<BookLoanDTO> CreateBookLoanAsync(Guid memberId, Guid bookId, DateTime dueDate);

    // Marks a book loan as returned
    Task<bool> MarkAsReturnedAsync(Guid loanId, DateTime returnDate);

    // Checks if a specific book is currently loaned out to a member
    Task<bool> IsBookLoanedToMemberAsync(Guid bookId, Guid memberId);

    // Retrieves loan history for a specific member
    Task<IEnumerable<BookLoanDTO>> GetLoanHistoryForMemberAsync(Guid memberId);

    // Retrieves overdue loans
    Task<IEnumerable<BookLoanDTO>> GetOverdueLoansAsync();
}
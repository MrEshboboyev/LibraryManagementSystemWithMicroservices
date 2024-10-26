using LibraryMS.Services.Membership.Application.DTOs;

namespace LibraryMS.Services.Membership.Application.Services;

public interface ILoanHistoryService
{
    // Retrieves all loan histories
    Task<IEnumerable<LoanHistoryDTO>> GetAllLoanHistoriesAsync();

    // Retrieves a loan history by its unique ID
    Task<LoanHistoryDTO?> GetLoanHistoryByIdAsync(Guid loanHistoryId);

    // Adds a new loan history record
    Task<LoanHistoryDTO> AddLoanHistoryAsync(LoanHistoryDTO loanHistoryDTO);

    // Updates an existing loan history record
    Task<bool> UpdateLoanHistoryAsync(LoanHistoryDTO loanHistoryDTO);

    // Deletes a loan history by ID
    Task<bool> DeleteLoanHistoryAsync(Guid loanHistoryId);

    // Retrieves loan histories for a specific member by their ID
    Task<IEnumerable<LoanHistoryDTO>> GetLoanHistoriesByMemberIdAsync(Guid memberId);

    // Checks if a specific book is currently loaned to a member
    Task<bool> IsBookLoanedToMemberAsync(Guid bookId, Guid memberId);
}
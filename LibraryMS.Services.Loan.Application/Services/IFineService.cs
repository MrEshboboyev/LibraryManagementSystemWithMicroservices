using LibraryMS.Services.Loan.Application.DTOs;

namespace LibraryMS.Services.Loan.Application.Services;

public interface IFineService
{
    // Retrieves all fines
    Task<IEnumerable<FineDTO>> GetAllFinesAsync();

    // Retrieves a fine by its unique ID
    Task<FineDTO?> GetFineByIdAsync(Guid fineId);

    // Creates a new fine for a loan
    Task<FineDTO> CreateFineAsync(Guid loanId, decimal amount, DateTime issuedDate, string reason = "Overdue");

    // Marks a fine as paid
    Task<bool> MarkFineAsPaidAsync(Guid fineId);

    // Retrieves fines for a specific member's loans
    Task<IEnumerable<FineDTO>> GetFinesForMemberAsync(Guid memberId);

    // Retrieves unpaid fines
    Task<IEnumerable<FineDTO>> GetUnpaidFinesAsync();
}
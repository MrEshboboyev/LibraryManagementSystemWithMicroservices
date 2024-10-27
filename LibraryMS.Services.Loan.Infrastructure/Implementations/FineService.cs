using AutoMapper;
using LibraryMS.Services.Loan.Application.Common.Interfaces;
using LibraryMS.Services.Loan.Application.DTOs;
using LibraryMS.Services.Loan.Application.Services;
using LibraryMS.Services.Loan.Domain.Entities;

namespace LibraryMS.Services.Loan.Infrastructure.Implementations;

public class FineService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IFineService
{
    // Retrieves all fines
    public async Task<IEnumerable<FineDTO>> GetAllFinesAsync()
    {
        var allFines = await _unitOfWork.Fine.GetAllAsync(
            includeProperties: "BookLoan");

        var mappedFines = _mapper.Map<IEnumerable<FineDTO>>(allFines);

        return mappedFines;
    }

    // Retrieves a fine by its unique ID
    public async Task<FineDTO?> GetFineByIdAsync(Guid fineId)
    {
        var fine = await _unitOfWork.Fine.GetAsync(
            filter: f => f.Id == fineId,
            includeProperties: "BookLoan");

        var mappedFine = _mapper.Map<FineDTO>(fine);

        return mappedFine;
    }

    // Creates a new fine for a loan
    public async Task<FineDTO> CreateFineAsync(Guid loanId, decimal amount, DateTime issuedDate, string reason = "Overdue")
    {
        Fine fineForDb = new()
        {
            LoanId = loanId,
            Amount = amount,
            IssuedDate = issuedDate,
            Reason = reason
        };

        await _unitOfWork.Fine.UpdateAsync(fineForDb);
        await _unitOfWork.SaveAsync();

        // mapped fine for prepare
        FineDTO fineDTO = new();
        _mapper.Map(fineForDb, fineDTO);

        return fineDTO;
    }

    // Marks a fine as paid
    public async Task<bool> MarkFineAsPaidAsync(Guid fineId)
    {
        var fineFromDb = await _unitOfWork.Fine.GetAsync(
            f => f.Id == fineId)
            ?? throw new Exception("Fine not found!");

        // update IsPaid field
        fineFromDb.IsPaid = true;

        await _unitOfWork.Fine.UpdateAsync(fineFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Retrieves fines for a specific member's loans
    public async Task<IEnumerable<FineDTO>> GetFinesForMemberAsync(Guid memberId)
    {
        var memberFines = await _unitOfWork.Fine.GetAllAsync(
            filter: f => f.BookLoan.MemberId == memberId,
            includeProperties: "BookLoan");

        var mappedFines = _mapper.Map<IEnumerable<FineDTO>>(memberFines);

        return mappedFines;
    }

    // Retrieves unpaid fines
    public async Task<IEnumerable<FineDTO>> GetUnpaidFinesAsync()
    {
        var unpaidFines = await _unitOfWork.Fine.GetAllAsync(
            filter: f => !f.IsPaid,
            includeProperties: "BookLoan");

        var mappedFines = _mapper.Map<IEnumerable<FineDTO>>(unpaidFines);

        return mappedFines;
    }
}
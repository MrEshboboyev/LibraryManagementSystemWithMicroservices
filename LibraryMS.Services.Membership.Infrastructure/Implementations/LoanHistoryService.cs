using AutoMapper;
using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Application.Services;
using LibraryMS.Services.Membership.Domain.Entities;

namespace LibraryMS.Services.Membership.Infrastructure.Implementations;

public class LoanHistoryService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), ILoanHistoryService
{
    // Retrieves all loan histories
    public async Task<IEnumerable<LoanHistoryDTO>> GetAllLoanHistoriesAsync()
    {
        var allLoanHistories = await _unitOfWork.LoanHistory.GetAllAsync(
            includeProperties: "Member");

        var mappedLoanHistories = _mapper.Map<IEnumerable<LoanHistoryDTO>>(allLoanHistories);

        return mappedLoanHistories;
    }

    // Retrieves a loan history by its unique ID
    public async Task<LoanHistoryDTO?> GetLoanHistoryByIdAsync(Guid loanHistoryId)
    {
        var loanHistory = await _unitOfWork.LoanHistory.GetAsync(
            filter: l => l.Id == loanHistoryId,
            includeProperties: "Member");

        var mappedLoanHistory = _mapper.Map<LoanHistoryDTO>(loanHistory);

        return mappedLoanHistory;
    }

    // Adds a new loan history record
    public async Task<LoanHistoryDTO> AddLoanHistoryAsync(LoanHistoryDTO loanHistoryDTO)
    {
        var loanHistoryForDB = _mapper.Map<LoanHistory>(loanHistoryDTO);

        await _unitOfWork.LoanHistory.AddAsync(loanHistoryForDB);
        await _unitOfWork.SaveAsync();

        _mapper.Map(loanHistoryForDB, loanHistoryDTO);

        return loanHistoryDTO;
    }

    // Updates an existing loan history record
    public async Task<bool> UpdateLoanHistoryAsync(LoanHistoryDTO loanHistoryDTO)
    {
        var loanHistoryFromDB = await _unitOfWork.LoanHistory.GetAsync(l => l.Id == loanHistoryDTO.Id)
            ?? throw new Exception("Loan history not found!");

        // mapping fields
        _mapper.Map(loanHistoryDTO, loanHistoryFromDB);

        await _unitOfWork.LoanHistory.UpdateAsync(loanHistoryFromDB);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes a loan history by ID
    public async Task<bool> DeleteLoanHistoryAsync(Guid loanHistoryId)
    {
        var loanHistoryFromDB = await _unitOfWork.LoanHistory.GetAsync(l => l.Id == loanHistoryId)
            ?? throw new Exception("Loan history not found!");

        await _unitOfWork.LoanHistory.RemoveAsync(loanHistoryFromDB);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Retrieves loan histories for a specific member by their ID
    public async Task<IEnumerable<LoanHistoryDTO>> GetLoanHistoriesByMemberIdAsync(Guid memberId)
    {
        var loanHistories = await _unitOfWork.LoanHistory.GetAllAsync(l => l.MemberId == memberId);

        var mappedHistories = _mapper.Map<IEnumerable<LoanHistoryDTO>>(loanHistories);

        return mappedHistories;
    }

    // Checks if a specific book is currently loaned to a member
    public async Task<bool> IsBookLoanedToMemberAsync(Guid bookId, Guid memberId)
    {
        var loanHistoryExist = await _unitOfWork.LoanHistory.AnyAsync(
            l => l.BookId == bookId && l.MemberId == memberId);

        return loanHistoryExist;
    }
}
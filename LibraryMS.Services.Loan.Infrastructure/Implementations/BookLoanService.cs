using AutoMapper;
using LibraryMS.Services.Loan.Application.Common.Interfaces;
using LibraryMS.Services.Loan.Application.DTOs;
using LibraryMS.Services.Loan.Application.Services;
using LibraryMS.Services.Loan.Domain.Entities;
using LibraryMS.Services.Loan.Domain.Enums;

namespace LibraryMS.Services.Loan.Infrastructure.Implementations;

public class BookLoanService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), IBookLoanService
{
    // Retrieves all book loans
    public async Task<IEnumerable<BookLoanDTO>> GetAllBookLoansAsync()
    {
        var allBookLoans = await _unitOfWork.BookLoan.GetAllAsync(
            includeProperties: "Fine");

        var mappedBookLoans = _mapper.Map<IEnumerable<BookLoanDTO>>(allBookLoans);

        return mappedBookLoans;
    }

    // Retrieves a specific book loan by its ID
    public async Task<BookLoanDTO?> GetBookLoanByIdAsync(Guid loanId)
    {
        var bookLoan = await _unitOfWork.BookLoan.GetAsync(
            filter: bl => bl.Id == loanId,
            includeProperties: "Fine");

        var mappedBookLoan = _mapper.Map<BookLoanDTO>(bookLoan);

        return mappedBookLoan;
    }

    // Creates a new book loan record
    public async Task<BookLoanDTO> CreateBookLoanAsync(Guid memberId, Guid bookId, DateTime dueDate)
    {
        BookLoan bookLoanForDb = new()
        {
            MemberId = memberId,
            BookId = bookId,
            DueDate = dueDate,
            BorrowedDate = DateTime.Now,
            Status = BookLoanStatus.Active
        };

        await _unitOfWork.BookLoan.AddAsync(bookLoanForDb);
        await _unitOfWork.SaveAsync();

        // mapping fields for prepare
        BookLoanDTO bookLoanDto = new();
        _mapper.Map(bookLoanForDb, bookLoanDto);

        return bookLoanDto;
    }

    // Marks a book loan as returned
    public async Task<bool> MarkAsReturnedAsync(Guid loanId, DateTime returnDate)
    {
        var loanFromDb = await _unitOfWork.BookLoan.GetAsync(
            bl => bl.Id == loanId) 
            ?? throw new Exception("Book Loan not found!");

        // mark as returned
        loanFromDb.ReturnedDate = returnDate;

        await _unitOfWork.BookLoan.UpdateAsync(loanFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Checks if a specific book is currently loaned out to a member
    public async Task<bool> IsBookLoanedToMemberAsync(Guid bookId, Guid memberId)
    {
        var loanExist = await _unitOfWork.BookLoan.AnyAsync(
            bl => bl.Id == bookId  && bl.MemberId == memberId);

        return loanExist;
    }

    // Retrieves loan history for a specific member
    public async Task<IEnumerable<BookLoanDTO>> GetLoanHistoryForMemberAsync(Guid memberId)
    {
        var memberBookLoans = await _unitOfWork.BookLoan.GetAllAsync(
            filter: bl => bl.MemberId == memberId,
            includeProperties: "Fine");

        var mappedBookLoans  = _mapper.Map<IEnumerable<BookLoanDTO>>(memberBookLoans);

        return mappedBookLoans;
    }

    // Retrieves overdue loans
    public async Task<IEnumerable<BookLoanDTO>> GetOverdueLoansAsync()
    {
        // Fetch all overdue loans
        var overdueLoans = await _unitOfWork.BookLoan.GetAllAsync(
            filter: loan => loan.DueDate < DateTime.UtcNow && 
            loan.ReturnedDate == null
        );

        // Map overdue loans to DTOs
        var overdueLoanDTOs = _mapper.Map<IEnumerable<BookLoanDTO>>(overdueLoans);

        return overdueLoanDTOs;
    }
}
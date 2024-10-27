using LibraryMS.Services.Loan.Domain.Enums;

namespace LibraryMS.Services.Loan.Application.DTOs;

public class BookLoanDTO
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookId { get; set; }
    public DateTime BorrowedDate { get; set; }       
    public DateTime DueDate { get; set; }            
    public DateTime? ReturnedDate { get; set; }      
    public BookLoanStatus Status { get; set; } = BookLoanStatus.Active; 
    public FineDTO? FineDTO { get; set; }
}
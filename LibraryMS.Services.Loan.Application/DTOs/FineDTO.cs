namespace LibraryMS.Services.Loan.Application.DTOs;

public class FineDTO
{
    public Guid Id { get; set; }
    public Guid LoanId { get; set; }
    public BookLoanDTO? BookLoanDTO { get; set; }
    public decimal Amount { get; set; }               
    public DateTime IssuedDate { get; set; }          
    public bool IsPaid { get; set; } = false;         
    public string Reason { get; set; } = "Overdue";   
}
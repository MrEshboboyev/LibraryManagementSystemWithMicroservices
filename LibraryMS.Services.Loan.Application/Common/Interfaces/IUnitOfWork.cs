namespace LibraryMS.Services.Loan.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IBookLoanRepository BookLoan { get; }
    IFineRepository Fine { get; }
    
    Task SaveAsync();
}

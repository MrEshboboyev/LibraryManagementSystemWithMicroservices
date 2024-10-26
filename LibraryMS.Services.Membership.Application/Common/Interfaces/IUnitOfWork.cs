namespace LibraryMS.Services.Membership.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IMemberRepository Member { get; }
    IMembershipTypeRepository MembershipType { get; }
    ILoanHistoryRepository LoanHistory { get; }
    
    Task SaveAsync();
}

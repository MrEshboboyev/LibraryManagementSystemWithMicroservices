namespace LibraryMS.Services.Membership.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IMemberRepository Member { get; }
    IMembershipTypeRepository MembershipType { get; }
    
    Task SaveAsync();
}

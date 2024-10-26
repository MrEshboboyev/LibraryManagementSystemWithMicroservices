using LibraryMS.Services.Membership.Domain.Entities;

namespace LibraryMS.Services.Membership.Application.DTOs;

public class MemberDTO
{
    public Guid Id { get; set; }
    public required string AppUserId { get; set; }
    public required MembershipTypeDTO MembershipType { get; set; } 
    public DateTime JoinDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<LoanHistory> LoanHistories { get; set; } = [];
}
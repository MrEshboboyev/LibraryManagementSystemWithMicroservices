namespace LibraryMS.Services.Membership.Domain.Entities;

public class Member
{
    public Guid Id { get; set; }

    // Link to the authentication user
    public required string AppUserId { get; set; }

    public required MembershipType MembershipType { get; set; } // Reference to MembershipType
    public DateTime JoinDate { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    // Navigation to loan history
    public ICollection<LoanHistory> LoanHistories { get; set; } = [];
}


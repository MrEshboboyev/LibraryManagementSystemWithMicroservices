namespace LibraryMS.Services.Membership.Domain.Entities;

public class Member
{
    public Guid Id { get; set; }

    // Link to the authentication user
    public required string AppUserId { get; set; }

    // Foreign key for MembershipType
    public Guid MembershipTypeId { get; set; } // FK reference
    
    public DateTime JoinDate { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public MembershipType MembershipType { get; set; } // Navigation property
}


namespace LibraryMS.Services.Membership.Domain.Entities;

public class MembershipType
{
    public Guid Id { get; set; }
    public required string Name { get; set; } // e.g., Regular, Premium
    public int MaxBooksAllowed { get; set; }
    public decimal MembershipFee { get; set; }

    // Navigation to members
    public ICollection<Member> Members { get; set; } = new List<Member>();
}

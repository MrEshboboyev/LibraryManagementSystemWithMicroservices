namespace LibraryMS.Services.Membership.Application.DTOs;

public class MembershipTypeDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; } 
    public int MaxBooksAllowed { get; set; }
    public decimal MembershipFee { get; set; }
    public ICollection<MemberDTO> MemberDTOs { get; set; } = [];
}
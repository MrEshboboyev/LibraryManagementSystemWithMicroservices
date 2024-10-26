namespace LibraryMS.Services.Membership.Application.DTOs;

public class LoanHistoryDTO
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public required MemberDTO MemberDTO { get; set; }

    public Guid BookId { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
}
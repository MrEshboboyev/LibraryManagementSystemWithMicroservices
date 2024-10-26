namespace LibraryMS.Services.Membership.Domain.Entities;

public class LoanHistory
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public required Member Member { get; set; }

    public Guid BookId { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
}

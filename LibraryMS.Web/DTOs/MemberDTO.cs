﻿namespace LibraryMS.Web.DTOs;

public class MemberDTO
{
    public Guid Id { get; set; }
    public required string AppUserId { get; set; }
    public Guid MembershipTypeId { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool IsActive { get; set; }
    public MembershipTypeDTO? MembershipTypeDTO { get; set; }
}
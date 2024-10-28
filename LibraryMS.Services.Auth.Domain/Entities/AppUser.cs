using Microsoft.AspNetCore.Identity;

namespace LibraryMS.Services.Auth.Domain.Entities;

public class AppUser : IdentityUser
{
    public required string FullName { get; set; }
    public required string Address { get; set; }
    public required DateTime DateOfBirth { get; set; }
}
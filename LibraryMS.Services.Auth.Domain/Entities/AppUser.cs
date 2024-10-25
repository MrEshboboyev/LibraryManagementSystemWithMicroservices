using Microsoft.AspNetCore.Identity;

namespace LibraryMS.Services.Auth.Domain.Entities;

public class AppUser : IdentityUser
{
    public required string FullName { get; set; }
}
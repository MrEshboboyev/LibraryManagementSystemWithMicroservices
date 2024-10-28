namespace LibraryMS.Services.Auth.Application.DTOs;

public class UserProfileDTO
{
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; } // Include if needed for display purposes
}

namespace LibraryMS.Services.Auth.Application.DTOs;

public class UserDTO
{
    public required string Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
}
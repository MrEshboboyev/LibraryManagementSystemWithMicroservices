namespace LibraryMS.Services.Auth.Application.DTOs;

public class LoginResponseDTO
{
    public required UserDTO User { get; set; }
    public required string Token { get; set; }
}


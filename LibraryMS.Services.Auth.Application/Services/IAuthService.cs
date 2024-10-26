using LibraryMS.Services.Auth.Application.DTOs;

namespace LibraryMS.Services.Auth.Application.Services;

public interface IAuthService
{
    Task<string> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
    Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
    Task<bool> AssignRoleAsync(string email);
}
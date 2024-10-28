using LibraryMS.Web.DTOs;

namespace LibraryMS.Web.Services.IServices;

public interface IAuthService
{
    Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);
    Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
    Task<ResponseDTO?> GetProfileAsync();
    Task<ResponseDTO?> UpdateProfileAsync(UserProfileDTO userProfileDTO);
}
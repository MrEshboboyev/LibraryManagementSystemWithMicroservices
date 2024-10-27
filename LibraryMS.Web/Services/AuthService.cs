using LibraryMS.Web.DTOs;
using LibraryMS.Web.Services.IServices;
using LibraryMS.Web.Utility;
using static LibraryMS.Web.Utility.SD;

namespace LibraryMS.Web.Services;

public class AuthService(IBaseService baseService) : IAuthService
{
    private readonly IBaseService _baseService = baseService;

    public async Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        RequestDTO requestDTO = new()
        {
            ApiType = ApiType.POST,
            Url = SD.AuthAPIBase + "/api/auth/login",
            Data = loginRequestDTO
        };

        return await _baseService.SendAsync(requestDTO, withBearer: false);
    }

    public async Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
    {
        RequestDTO requestDTO = new()
        {
            ApiType = ApiType.POST,
            Url = SD.AuthAPIBase + "/api/auth/register",
            Data = registrationRequestDTO
        };

        return await _baseService.SendAsync(requestDTO, withBearer: false);
    }
}


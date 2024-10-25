using LibraryMS.Services.Auth.Application.Common.Models;
using LibraryMS.Services.Auth.Application.DTOs;
using LibraryMS.Services.Auth.Domain.Entities;

namespace LibraryMS.Services.Auth.Application.Services;

public interface IAuthService
{
    Task<ResponseDTO<string>> LoginAsync(LoginModel loginModel);
    Task<ResponseDTO<string>> RegisterAsync(RegisterModel registerModel);
    Task<ResponseDTO<string>> GenerateJwtToken(AppUser user, IEnumerable<string> roles);
}


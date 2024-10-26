using LibraryMS.Services.Auth.Domain.Entities;

namespace LibraryMS.Services.Auth.Application.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(AppUser appUser, IEnumerable<string> roles);
}
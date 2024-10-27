using LibraryMS.Web.DTOs;

namespace LibraryMS.Web.DTOs;

public class LoginResponseDTO
{
    public required UserDTO User { get; set; }
    public required string Token { get; set; }
}


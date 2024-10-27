using System.ComponentModel.DataAnnotations;

namespace LibraryMS.Web.DTOs;

public class LoginRequestDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}


using System.ComponentModel.DataAnnotations;

namespace LibraryMS.Services.Auth.Application.Common.Models;

public class RegisterModel
{
    public required string FullName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public required string UserName { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password and confirm password must be match.")]
    public required string ConfirmPassword { get; set; }
}
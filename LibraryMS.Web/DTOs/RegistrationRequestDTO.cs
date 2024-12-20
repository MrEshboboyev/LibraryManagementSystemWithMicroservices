﻿namespace LibraryMS.Web.DTOs;

public class RegistrationRequestDTO
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string FullName { get; set; }
    public required string Password { get; set; }
    public required string Address { get; set; }
    public required DateTime DateOfBirth { get; set; }
}

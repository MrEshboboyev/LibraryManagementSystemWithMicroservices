﻿namespace LibraryMS.Services.Auth.Application.DTOs;

public class LoginRequestDTO
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}

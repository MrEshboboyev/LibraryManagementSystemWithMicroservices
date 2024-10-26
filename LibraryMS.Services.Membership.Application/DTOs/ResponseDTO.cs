﻿namespace LibraryMS.Services.Membership.Application.DTOs;

public class ResponseDTO
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";
}
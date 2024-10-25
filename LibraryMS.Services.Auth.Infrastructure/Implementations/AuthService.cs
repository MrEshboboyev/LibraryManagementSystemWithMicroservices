﻿using LibraryMS.Services.Auth.Application.Common.Utility;
using LibraryMS.Services.Auth.Application.DTOs;
using LibraryMS.Services.Auth.Application.Services;
using LibraryMS.Services.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LibraryMS.Services.Auth.Infrastructure.Implementations;

public class AuthService(UserManager<AppUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator) : IAuthService
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<bool> AssignRoleAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            await _userManager.AddToRoleAsync(user, SD.Role_User);
            return true;
        }

        return false;
    }

    public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        // Fetching user from the database
        var userFromDb = await _userManager.FindByNameAsync(loginRequestDTO.UserName);

        bool isValid = await _userManager.CheckPasswordAsync(userFromDb, loginRequestDTO.Password);

        if (userFromDb == null || isValid == false)
        {
            return new LoginResponseDTO() { User = default!, Token = "" };
        }

        // Fetch user roles
        var userRoles = await _userManager.GetRolesAsync(userFromDb);

        // Generate JWT token
        var generatedToken = _jwtTokenGenerator.GenerateToken(userFromDb, userRoles);

        UserDTO userDTO = new()
        {
            Id = userFromDb.Id,
            FullName = userFromDb.FullName,
            Email = userFromDb.Email!,
            UserName = userFromDb.UserName!
        };

        LoginResponseDTO? loginResponseDto = new()
        {
            User = userDTO,
            Token = generatedToken
        };

        return loginResponseDto;
    }

    public async Task<string> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
    {
        AppUser user = new()
        {
            UserName = registrationRequestDTO.UserName,
            Email = registrationRequestDTO.Email,
            NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
            NormalizedUserName = registrationRequestDTO.UserName.ToUpper(),
            FullName = registrationRequestDTO.FullName
        };

        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
            if (result.Succeeded)
            {
                // assigning role
                var assignRoleResult = await AssignRoleAsync(user.Email);
                if (!assignRoleResult)
                {
                    return "Assign role process failed!";
                }
                
                var userToReturn = await _userManager.FindByNameAsync(registrationRequestDTO.UserName);

                UserDTO userDto = new()
                {
                    FullName = userToReturn!.FullName,
                    UserName = userToReturn.UserName!,
                    Email = userToReturn.Email!,
                    Id = userToReturn.Id
                };

                return "";
            }
            else
            {
                return result.Errors.FirstOrDefault().Description;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Error encountered";
    }
}

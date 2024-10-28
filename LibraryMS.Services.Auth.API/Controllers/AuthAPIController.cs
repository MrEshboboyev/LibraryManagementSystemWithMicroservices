using LibraryMS.Services.Auth.Application.DTOs;
using LibraryMS.Services.Auth.Application.Services;
using LibraryMS.Services.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryMS.Services.Auth.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthAPIController(IAuthService authService,
    UserManager<AppUser> userManager) : ControllerBase
{
    private readonly IAuthService _authService = authService;
    private readonly UserManager<AppUser> _userManager = userManager;
    protected ResponseDTO _response = new();

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
    {
        var errorMessage = await _authService.RegisterAsync(model);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            _response.IsSuccess = false;
            _response.Message = errorMessage;
            return BadRequest(_response);
        }

        return Ok(_response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        var loginResponse = await _authService.LoginAsync(model);
        if (loginResponse.User == null)
        {
            _response.IsSuccess = false;
            _response.Message = "Username or password incorrect";
            return BadRequest(_response);
        }
        _response.Result = loginResponse;

        return Ok(_response);
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound("User not found");

        var profileDto = new UserProfileDTO
        {
            FullName = user.FullName,
            Address = user.Address,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email
        };

        _response.Result = profileDto;

        return Ok(_response);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UserProfileDTO profileDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound("User not found");

        user.FullName = profileDto.FullName;
        user.Address = profileDto.Address;
        user.DateOfBirth = profileDto.DateOfBirth;
        user.Email = profileDto.Email;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to update profile");
        }

        return Ok(_response);
    }
}

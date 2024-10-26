using LibraryMS.Services.Auth.Application.DTOs;
using LibraryMS.Services.Auth.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Auth.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthAPIController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;
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
}

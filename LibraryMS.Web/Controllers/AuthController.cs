using LibraryMS.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using LibraryMS.Web.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace LibraryMS.Web.Controllers;

public class AuthController(IAuthService authService, ITokenProvider tokenProvider) : Controller
{
    private readonly IAuthService _authService = authService;
    private readonly ITokenProvider _tokenProvider = tokenProvider;

    [HttpGet]
    public IActionResult Login()
    {
        LoginRequestDTO loginRequestDTO = new();
        return View(loginRequestDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDTO obj)
    {
        ResponseDTO? responseDTO = await _authService.LoginAsync(obj);

        if (responseDTO != null && responseDTO.IsSuccess)
        {
            LoginResponseDTO? loginResponseDTO =
                JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(responseDTO.Result));

            // sign in user applied
            await SignInUser(loginResponseDTO);

            // set token for user
            _tokenProvider.SetToken(loginResponseDTO.Token);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            TempData["error"] = responseDTO!.Message;
            return View(obj);
        }
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationRequestDTO obj)
    {
        ResponseDTO? result = await _authService.RegisterAsync(obj);

        if (result != null && result.IsSuccess)
        {
            TempData["success"] = "Registration Successful";
            return RedirectToAction(nameof(Login));
        }
        else
        {
            TempData["error"] = result!.Message;
        }

        return View(obj);
    }


    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        _tokenProvider.ClearToken();
        return RedirectToAction("Index", "Home");
    }

    #region Profile
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var responseDTO = await _authService.GetProfileAsync();
        if (responseDTO != null && responseDTO.IsSuccess)
        {
            UserProfileDTO? userProfileDTO = 
                JsonConvert.DeserializeObject<UserProfileDTO>(Convert.ToString(responseDTO.Result));

            return View(userProfileDTO);
        }
        else
        {
            TempData["error"] = responseDTO.Message;
            return RedirectToAction("Index", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Profile(UserProfileDTO obj)
    {
        ResponseDTO? result = await _authService.UpdateProfileAsync(obj);

        if (result != null && result.IsSuccess)
        {
            TempData["success"] = "User Profile updated Successfully";
            return RedirectToAction(nameof(Profile));
        }
        else
        {
            TempData["error"] = result?.Message ?? "An error occurred while updating the profile.";
        }

        return View(obj);
    }
    #endregion
    // Sign In User
    private async Task SignInUser(LoginResponseDTO model)
    {
        var handler = new JwtSecurityTokenHandler();

        var jwt = handler.ReadJwtToken(model.Token);

        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

        // adding claims
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
            jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
            jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
            jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

        identity.AddClaim(new Claim(ClaimTypes.Name,
            jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
        identity.AddClaim(new Claim(ClaimTypes.Role,
            jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));


        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
}


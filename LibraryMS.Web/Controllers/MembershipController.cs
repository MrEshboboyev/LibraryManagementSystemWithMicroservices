using Microsoft.AspNetCore.Mvc;
using LibraryMS.Web.Services.IServices;
using System.Security.Claims;
using Newtonsoft.Json;
using LibraryMS.Web.DTOs;

namespace LibraryMS.Web.Controllers;

public class MembershipController(IMembershipService membershipService) : Controller
{
    private readonly IMembershipService _membershipService = membershipService;

    [HttpGet("details")]
    public async Task<IActionResult> Details()
    {
        var responseDTO = await _membershipService.GetMembershipDetailsAsync();
        if (responseDTO != null && responseDTO.IsSuccess)
        {
            MemberDTO? memberDTO =
                JsonConvert.DeserializeObject<MemberDTO>(Convert.ToString(responseDTO.Result));

            return View(memberDTO);
        }
        else
        {
            TempData["error"] = responseDTO.Message;
            return RedirectToAction("Index", "Home");
        }
    }
}
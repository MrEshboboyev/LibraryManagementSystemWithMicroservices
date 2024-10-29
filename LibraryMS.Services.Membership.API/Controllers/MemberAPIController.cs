using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Membership.API.Controllers;

[Route("api/members")]
[ApiController]
public class MemberAPIController(IMemberService memberService) : ControllerBase
{
    private readonly IMemberService _memberService = memberService;
    private ResponseDTO _response = new();

    // POST
    // /api/members
    // Register a new member
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] MemberDTO memberDTO)
    {
        try
        {
            var result = await _memberService.AddMemberAsync(memberDTO);
            _response.Result = result;
        }
        catch (Exception ex) 
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/members
    // Get all members (with pagination, filtering options)
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _memberService.GetAllMembersAsync();
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/members/{id}
    // Get a specific member by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _memberService.GetMemberByIdAsync(id);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // PUT
    // /api/members/{id}
    // Update member details
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] MemberDTO memberDTO)
    {
        try
        {
            var result = await _memberService.UpdateMemberAsync(memberDTO);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // DELETE
    // /api/members/{id}
    // Delete a member
    [HttpDelete("{id:guid}")]
    public async Task<ResponseDTO> Delete(Guid id)
    {
        try
        {
            var result = await _memberService.DeleteMemberAsync(id);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    // GET
    // /api/members/{id}/status
    // Check if a member is active
    [HttpGet("{id:guid}/status")]
    public async Task<ResponseDTO> GetStatus(Guid id)
    {
        try
        {
            var result = await _memberService.IsMemberActiveAsync(id);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
}


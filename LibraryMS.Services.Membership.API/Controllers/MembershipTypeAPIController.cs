using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Membership.API.Controllers;

[Route("api/membership-types")]
[ApiController]
public class MembershipTypeAPIController(IMembershipTypeService membershipTypeService) : ControllerBase
{
    private readonly IMembershipTypeService _membershipTypeService = membershipTypeService;
    private ResponseDTO _response = new();

    // POST
    // /api/membership-types
    // Create a new membership type
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] MembershipTypeDTO membershipTypeDTO)
    {
        try
        {
            var result = await _membershipTypeService.AddMembershipTypeAsync(membershipTypeDTO);
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
    // /api/membership-types
    // Get all membership types
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _membershipTypeService.GetAllMembershipTypesAsync();
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
    // /api/membership-types/{id}
    // Get a specific membership type by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _membershipTypeService.GetMembershipTypeByIdAsync(id);
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
    // /api/membership-types
    // Update a membership type
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] MembershipTypeDTO membershipTypeDTO)
    {
        try
        {
            var result = await _membershipTypeService.UpdateMembershipTypeAsync(membershipTypeDTO);
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
    // /api/membership-types/{id}
    // Delete a membership type
    [HttpDelete("{id:guid}")]
    public async Task<ResponseDTO> Delete(Guid id)
    {
        try
        {
            var result = await _membershipTypeService.DeleteMembershipTypeAsync(id);
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
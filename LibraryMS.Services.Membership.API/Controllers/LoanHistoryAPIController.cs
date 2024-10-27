using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Membership.API.Controllers;

[Route("api/loans")]
[ApiController]
public class LoanHistoryAPIController(ILoanHistoryService loanHistoryService) : ControllerBase
{
    private readonly ILoanHistoryService _loanHistoryService = loanHistoryService;
    private ResponseDTO _response = new();

    // POST
    // /api/loans
    // Create a new membership type
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] LoanHistoryDTO loanHistoryDTO)
    {
        try
        {
            var result = await _loanHistoryService.AddLoanHistoryAsync(loanHistoryDTO);
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
    // /api/loans
    // Get all loan histories
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _loanHistoryService.GetAllLoanHistoriesAsync();
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
    // /api/loans/{id}
    // Get a specific loan history by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _loanHistoryService.GetLoanHistoryByIdAsync(id);
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
    // /api/loans
    // Update a loan history record (e.g., mark as returned)
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] LoanHistoryDTO loanHistoryDTO)
    {
        try
        {
            var result = await _loanHistoryService.UpdateLoanHistoryAsync(loanHistoryDTO);
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
    // /api/loans/{id}
    // Delete a loan history record
    [HttpDelete("{id:guid}")]
    public async Task<ResponseDTO> Delete(Guid id)
    {
        try
        {
            var result = await _loanHistoryService.DeleteLoanHistoryAsync(id);
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
    // /api/loans/member/{memberId}
    // Get loan histories by member ID
    [HttpGet("member/{memberId:guid}")]
    public async Task<ResponseDTO> GetLoans(Guid memberId)
    {
        try
        {
            var result = await _loanHistoryService.GetLoanHistoriesByMemberIdAsync(memberId);
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
    // /api/loans/check
    // Check if a book is currently loaned to a member
    [HttpGet("check")]
    public async Task<ResponseDTO> Check(Guid memberId, Guid bookId)
    {
        try
        {
            var result = await _loanHistoryService.IsBookLoanedToMemberAsync(bookId, memberId);
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

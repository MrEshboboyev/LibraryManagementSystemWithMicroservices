using LibraryMS.Services.Loan.Application.DTOs;
using LibraryMS.Services.Loan.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Loan.API.Controllers;

[Route("api/fines")]
[ApiController]
public class FineAPIController(IFineService fineService) : ControllerBase
{
    private readonly IFineService _fineService = fineService;
    private ResponseDTO _response = new();

    // POST
    // /api/fines
    // Create a new fine for an overdue loan
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] FineDTO fineDTO)
    {
        try
        {
            var result = await _fineService.CreateFineAsync(fineDTO.LoanId, fineDTO.Amount, fineDTO.IssuedDate, fineDTO.Reason);
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
    // /api/fines
    // Get all fines (with pagination/filter options)
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _fineService.GetAllFinesAsync();
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
    // /api/fines/{id}
    // Get details of a specific fine by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _fineService.GetFineByIdAsync(id);
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
    // /api/fines/{id}/pay
    // Mark a fine as paid
    [HttpPut("{id:guid}/pay")]
    public async Task<ResponseDTO> Put(Guid id)
    {
        try
        {
            var result = await _fineService.MarkFineAsPaidAsync(id);
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
    // /api/fines/member/{memberId}
    // Get a list of fines for a specific member
    [HttpGet("member/{id:guid}")]
    public async Task<ResponseDTO> GetByMember(Guid id)
    {
        try
        {
            var result = await _fineService.GetFinesForMemberAsync(id);
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
    // /api/fines/unpaid
    // Get a list of all unpaid fines
    [HttpGet("unpaid")]
    public async Task<ResponseDTO> GetUnpaids()
    {
        try
        {
            var result = await _fineService.GetUnpaidFinesAsync();
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


using LibraryMS.Services.Loan.Application.DTOs;
using LibraryMS.Services.Loan.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Loan.API.Controllers;

[Route("api/bookloans")]
[ApiController]
public class BookLoanAPIController(IBookLoanService bookLoanService) : ControllerBase
{
    private readonly IBookLoanService _bookLoanService = bookLoanService;
    private ResponseDTO _response = new();

    // POST
    // /api/bookloans
    // Create a new book loan (borrow a book)
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] BookLoanDTO bookLoanDTO)
    {
        try
        {
            var result = await _bookLoanService.CreateBookLoanAsync(bookLoanDTO.MemberId,
                bookLoanDTO.BookId, bookLoanDTO.DueDate);
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
    // /api/bookloans/{id}/return
    // Mark a loan as returned
    [HttpPut("{id:guid}/return")]
    public async Task<ResponseDTO> Post(Guid id)
    {
        try
        {
            var result = await _bookLoanService.MarkAsReturnedAsync(id, DateTime.Now);
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
    // /api/bookloans
    // Get all book loans (with pagination/filter options)
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _bookLoanService.GetAllBookLoansAsync();
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
    // /api/bookloans/{id}
    // Get details of a specific book loan by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _bookLoanService.GetBookLoanByIdAsync(id);
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
    // /api/bookloans/fine/{fineId}
    // Get loan history for a specific fine
    [HttpGet("fine/{fineId:guid}")]
    public async Task<ResponseDTO> GetByFine(Guid memberId)
    {
        try
        {
            var result = await _bookLoanService.GetLoanHistoryForMemberAsync(memberId);
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
    // /api/bookloans/overdue
    // Get a list of all overdue loans
    [HttpGet("overdue")]
    public async Task<ResponseDTO> OverDue()
    {
        try
        {
            var result = await _bookLoanService.GetOverdueLoansAsync();
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

using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Catalog.API.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController(IPublisherService publisherService) : ControllerBase
{
    private readonly IPublisherService _publisherService = publisherService;
    private ResponseDTO _response = new();

    // POST
    // /api/publishers
    // Create a new publisher
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] PublisherDTO publisherDTO)
    {
        try
        {
            var result = await _publisherService.AddPublisherAsync(publisherDTO);
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
    // /api/publishers
    // Get all publishers
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _publisherService.GetAllPublishersAsync();
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
    // /api/publishers/{id}
    // Get a specific publisher by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _publisherService.GetPublisherByIdAsync(id);
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
    // /api/publishers
    // Update a publisher
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] PublisherDTO publisherDTO)
    {
        try
        {
            var result = await _publisherService.UpdatePublisherAsync(publisherDTO);
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
    // /api/publishers/{id}
    // Delete a publisher
    [HttpDelete("{id:guid}")]
    public async Task<ResponseDTO> Delete(Guid id)
    {
        try
        {
            var result = await _publisherService.DeletePublisherAsync(id);
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


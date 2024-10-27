using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Services.Catalog.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;
    private ResponseDTO _response = new();

    // POST
    // /api/categories
    // Add a new category
    [HttpPost]
    public async Task<ResponseDTO> Post([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            var result = await _categoryService.AddCategoryAsync(categoryDTO);
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
    // /api/categories
    // Get all categories
    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        try
        {
            var result = await _categoryService.GetAllCategoriesAsync();
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
    // /api/categories/{id}
    // Get a specific category by ID
    [HttpGet("{id:guid}")]
    public async Task<ResponseDTO> Get(Guid id)
    {
        try
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
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
    // /api/categories
    // Update a category’s information
    [HttpPut]
    public async Task<ResponseDTO> Put([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            var result = await _categoryService.UpdateCategoryAsync(categoryDTO);
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
    // /api/categories/{id}
    // Delete a category by ID
    [HttpDelete("{id:guid}")]
    public async Task<ResponseDTO> Delete(Guid id)
    {
        try
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
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


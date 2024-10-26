using LibraryMS.Services.Catalog.Application.DTOs;

namespace LibraryMS.Services.Catalog.Application.Services;

public interface ICategoryService
{
    // Retrieves all categories
    Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();

    // Retrieves a category by its unique ID
    Task<CategoryDTO?> GetCategoryByIdAsync(Guid categoryId);

    // Adds a new category to the catalog
    Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO);

    // Updates an existing category's information
    Task<bool> UpdateCategoryAsync(CategoryDTO categoryDTO);

    // Deletes a category by its ID
    Task<bool> DeleteCategoryAsync(Guid categoryId);
}
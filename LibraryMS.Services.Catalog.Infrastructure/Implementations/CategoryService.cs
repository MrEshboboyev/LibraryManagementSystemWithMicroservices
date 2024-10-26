using AutoMapper;
using LibraryMS.Services.Catalog.Application.Common.Interfaces;
using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Application.Services;
using LibraryMS.Services.Catalog.Domain.Entities;

namespace LibraryMS.Services.Catalog.Infrastructure.Implementations;

public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : 
    BaseService(unitOfWork, mapper), ICategoryService
{
    // Retrieves all categories
    public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
    {
        var allCategories = await _unitOfWork.Category.GetAllAsync(
            includeProperties: "Books");

        var mappedCategories = _mapper.Map<IEnumerable<CategoryDTO>>(allCategories);

        return mappedCategories;
    }

    // Retrieves a category by ID
    public async Task<CategoryDTO?> GetCategoryByIdAsync(Guid categoryId)
    {
        var category = await _unitOfWork.Category.GetAsync(
            filter : m => m.Id == categoryId,
            includeProperties: "Books")
            ?? throw new Exception("Category not found!");

        var mappedCategory = _mapper.Map<CategoryDTO>(category);

        return mappedCategory;
    }

    // Adds a new category to the catalog
    public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO)
    {
        var categoryForDb = _mapper.Map<Category>(categoryDTO);

        await _unitOfWork.Category.AddAsync(categoryForDb);
        await _unitOfWork.SaveAsync();

        // mapping db fields
        _mapper.Map(categoryForDb, categoryDTO);

        return categoryDTO;
    }

    // Updates an existing category's information
    public async Task<bool> UpdateCategoryAsync(CategoryDTO categoryDTO)
    {
        var memberFromDb = await _unitOfWork.Category.GetAsync(m => m.Id == categoryDTO.Id)
            ?? throw new Exception("Category not found!");

        // mapping fields
        _mapper.Map(categoryDTO, memberFromDb);

        await _unitOfWork.Category.UpdateAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }

    // Deletes a category by its ID
    public async Task<bool> DeleteCategoryAsync(Guid categoryId)
    {
        var memberFromDb = await _unitOfWork.Category.GetAsync(m => m.Id == categoryId)
            ?? throw new Exception("Category not found!");

        await _unitOfWork.Category.RemoveAsync(memberFromDb);
        await _unitOfWork.SaveAsync();

        return true;
    }
}


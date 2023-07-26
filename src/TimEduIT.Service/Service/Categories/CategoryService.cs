using Microsoft.Extensions.Caching.Memory;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.Interfaces.Categories;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Domain.Entities.Categories;
using TimEduIT.Domain.Exceptions.Category;
using TimEduIT.Domain.Exceptions.File;
using TimEduIT.Service.Common.Helpers;
using TimEduIT.Service.Dtos.Categories;
using TimEduIT.Service.Interfaces.Categories;
using TimEduIT.Service.Interfaces.Common;

namespace TimEduIT.Service.Service.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _fileService;
    private readonly IMemoryCache _memoryCache;

    public CategoryService(ICategoryRepository categoryRepository,
             IFileService fileService,
             IMemoryCache memoryCache)
    {
        _categoryRepository = categoryRepository;
        _fileService = fileService;
        _memoryCache = memoryCache;
    }

    public async Task<long> CountAsync() => await _categoryRepository.CountAsync();


    public async Task<bool> CreateAsync(CategoryCreatDto dto)
    {
        Category category = new Category()
        {
            Name = dto.Name,
            Description = dto.Description,
            
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _categoryRepository.CreateAsync(category);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        var dbResult = await _categoryRepository.DeleteAsync(categoryId);
        return dbResult > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var result = await _categoryRepository.GetAllAsync(@params);
        return result;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        // parse new items to category
        category.Name = dto.Name;
        category.Description = dto.Description;

        // else category old image have to save

        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _categoryRepository.UpdateAsync(categoryId, category);
        return dbResult > 0;
    }
}

using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.Interfaces.Categories;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Domain.Entities.Categories;
using TimEduIT.Service.Common.Helpers;
using TimEduIT.Service.Dtos.Categories;
using TimEduIT.Service.Interfaces.Categories;

namespace TimEduIT.Service.Service.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(CategoryCreatDto dto)
    {
        
    }

    public Task<bool> DeleteAsync(long categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var result = await _categoryRepository.GetAllAsync(@params);
        return result;
    }

    public Task<Category> GetByIdAsync(long categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}

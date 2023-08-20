using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.Infrastructure.Repositories.Admin;

public class CategoryRepository : ICategoryRepository
{
    public Task<IEnumerable<CategoryFullViewModel>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategorySampleViewModel>> GetSampleCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryFullViewModel> GetCategoryByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task NewCategoryAsync(CategoryFullBindingModel model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(CategoryFullBindingModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}

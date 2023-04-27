using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<CategoryViewModel>> GetCategoriesAsync();

    Task<CategoryViewModel> GetCategoryById(Guid id);

    Task<CategoryViewModel> AddCategoryAsync(CategoryFullBindingModel model);

    Task UpdateCategoryAsync(CategoryFullBindingModel model);

    Task DeleteCategoryAsync(Guid id);
}

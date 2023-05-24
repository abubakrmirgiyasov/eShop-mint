using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface ISubCategoryRepository
{
    Task<List<SubCategoryFullViewModel>> GetSubCategoriesAsync();

    Task<List<SubCategoryOnlylViewModel>> GetSubCategoriesOnlyAsync();

    Task<SubCategoryFullViewModel> GetSubCategoryByIdAsync(Guid id);

    Task<SubCategoryFullViewModel> AddSubCategoryAsync(SubCategoryBindingModel model);

    Task UpdateSubCategoryAsync(SubCategoryBindingModel model);

    Task DeleteSubCategoryAsync(Guid id);
}

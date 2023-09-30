using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.WebApp.Admin.Repositories.Interfaces;

public interface ISubCategoryRepository
{
    Task<IEnumerable<SubCategoryFullViewModel>> GetSubCategoriesAsync();

    Task<IEnumerable<SubCategorySampleViewModel>> GetSampleSubCategoriesAsync();

    Task<SubCategoryFullViewModel> GetSubCategoryByIdAsync(Guid id);

    Task CreateAsync(SubCategoryFullBindingModel model);

    Task UpdateAsync(SubCategoryFullBindingModel model);

    Task DeleteAsync(Guid id);
}

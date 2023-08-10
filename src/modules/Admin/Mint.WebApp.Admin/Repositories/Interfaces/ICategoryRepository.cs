using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.Infrastructure.Repositories.Admin.Interfaces;

/// <summary>
/// Category repository Interface
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CategoryFullViewModel>> GetCategoriesAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CategorySampleViewModel>> GetSampleCategoriesAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<CategoryFullViewModel> GetCategoryByIdAsync(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task NewCategoryAsync(CategoryFullBindingModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task UpdateCategoryAsync(CategoryFullBindingModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteCategoryAsync(Guid id);
}

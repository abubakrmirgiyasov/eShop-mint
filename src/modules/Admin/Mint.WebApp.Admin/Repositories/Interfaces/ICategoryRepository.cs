using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.Infrastructure.Repositories.Admin.Interfaces;

/// <summary>
/// Category repository Interface
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category, Guid>
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
    Task<IEnumerable<Category>> GetCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CategorySampleViewModel>> GetSampleCategoriesAsync();

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

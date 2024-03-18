using Mint.Domain.Models.Admin.Categories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <summary>
/// Category repository Interface
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category, Guid>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<Category>> GetCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default);
}

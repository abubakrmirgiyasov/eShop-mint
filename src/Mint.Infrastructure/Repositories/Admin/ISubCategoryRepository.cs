using Mint.Domain.Models.Admin.Categories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <summary>
/// Sub Category Base Repository
/// </summary>
public interface ISubCategoryRepository : IBaseRepository<SubCategory, Guid>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="search"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SubCategory>> GetSubCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Sub Category Repository
/// </summary>
public interface ISubCategoryRepository : IGenericRepository<SubCategory>
{
    /// <summary>
    /// Retrieves a collection of subcategories.
    /// </summary>
    /// <param name="searchPhrase"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(List<SubCategory>, int)> GetSubCategoriesAsync(string? searchPhrase = default, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection of subcategories link.
    /// </summary>
    /// <param name="search"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<string>> GetSubCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection of simplified subcategories.
    /// </summary>
    /// <param name="search"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<SubCategory>> GetSimpleSubCategoriesAsync(string? search = default, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a subcategory info by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubCategory> GetSubCategoryInfoAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
}

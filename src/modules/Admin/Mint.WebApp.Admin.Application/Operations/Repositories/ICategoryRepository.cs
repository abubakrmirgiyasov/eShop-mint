using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Category Repository
/// </summary>
public interface ICategoryRepository : IGenericRepository<Category>
{
    /// <summary>
    /// Retrieves a list of categories based on the specified search phrase, pagination parameters, and cancellation token.
    /// </summary>
    /// <param name="searchPhrase"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(List<Category>, int)> GetCategoriesAsync(string? searchPhrase = default, SortType sorter = SortType.Ascending, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a category by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection of categories link based on the specified search criteria.
    /// </summary>
    /// <returns></returns>
    Task<List<string>> GetCategoriesLinkAsync(string? searchPhrase = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of common categories asynchronously.
    /// </summary>
    /// <param name="searchPhrase"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A task representing the asynchronous operation. The result is a list of <see cref="Category"/> instances, where label is name and value is Id.</returns>
    Task<List<Category>> GetCommonCategoriesAsync(string? searchPhrase = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a common category by unique identifier asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Category> GetSampleCategoryById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a category with photo by unique identifier asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Category?> GetCategoryWithPhotoAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a category with list of subCategories asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Category> GetCategoryWithSubCategoriesAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
}

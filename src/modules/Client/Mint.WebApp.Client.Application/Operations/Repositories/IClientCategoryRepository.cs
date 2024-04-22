using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.WebApp.Client.Application.Operations.Repositories;

/// <summary>
/// Client Category Repository
/// </summary>
public interface IClientCategoryRepository : IGenericRepository<Category>
{
    /// <summary>
    /// Retrieves all categories(catalogs - menu).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default);
}

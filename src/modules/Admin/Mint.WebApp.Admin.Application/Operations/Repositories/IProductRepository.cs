using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Models.Admin.Products;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Product Repository
/// </summary>
public interface IProductRepository : IGenericRepository<Product>
{
    /// <summary>
    /// Retrieves a list of products.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="searchPhrase"></param>
    /// <param name="sort"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(List<Product>, int)> GetProductsAsync(
        Guid userId,
        string? searchPhrase = default,
        SortType sort = SortType.Ascending,
        int pageIndex = 0,
        int pageSize = 25,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a product info by unique identifier.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Product> GetProductInfoAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product with categories by unique identifier.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Product> GetProductWithCategoriesAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by unique identifier with product photos.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Product> GetProductWithPhotosAsync(Guid productId, bool asNoTracking = false, CancellationToken cancellationToken = default);
}

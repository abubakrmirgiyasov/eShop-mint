using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Products;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Discount Repository
/// </summary>
public interface IDiscountRepository : IGenericRepository<Discount>
{
    /// <summary>
    /// Retrieves a list of discounts of current user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Discount>> GetDiscountsByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a discount by product id.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Discount?> GetDiscountByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken = default
    );
}

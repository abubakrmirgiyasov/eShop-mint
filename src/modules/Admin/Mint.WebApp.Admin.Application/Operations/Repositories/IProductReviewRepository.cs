using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Products;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Product Review Repository
/// </summary>
public interface IProductReviewRepository : IGenericRepository<ProductReview>
{
    /// <summary>
    /// Retrieves a collection of product reviews.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="searchPhrase"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(List<ProductReview>, int)> GetProductReviewsAsync(
        DateTime from,
        DateTime to,
        Guid sellerId,
        int[] rating,
        bool onlyPluses,
        bool onlyMinuses,
        string? searchPhrase = default,
        int pageIndex = 0,
        int pageSize = 25,
        CancellationToken cancellationToken = default
    );
}

using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

internal sealed class ProductReviewRepository(ApplicationDbContext context)
    : GenericRepository<ProductReview>(context), IProductReviewRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<(List<ProductReview>, int)> GetProductReviewsAsync(
        DateTime from, 
        DateTime to,
        Guid sellerId,
        int[] rating,
        bool onlyPluses,
        bool onlyMinuses,
        string? searchPhrase = null,
        int pageIndex = 0, 
        int pageSize = 25, 
        CancellationToken cancellationToken = default)
    {
        var query = _context.ProductReviews.AsQueryable();

        query = query
            .AsNoTracking()
            .Where(x => x.Product.Store!.UserId == sellerId);

        query = query.Where(x => x.CreatedDate >= from && x.CreatedDate <= to);

        if (rating.Length == 2)
            query = query.Where(x => x.Rating >= rating[0] && x.Rating <= rating[1]);

        if (onlyPluses)
            query = query.Where(x => !string.IsNullOrEmpty(x.Pluses));

        if (onlyMinuses)
            query = query.Where(x => !string.IsNullOrEmpty(x.Minuses));

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            query = query.Where(x =>
                x.Text!.Contains(searchPhrase)
                || x.Pluses!.Contains(searchPhrase)
                || x.Minuses!.Contains(searchPhrase)
            );
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var reviews = await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (reviews, totalCount);
    }
}

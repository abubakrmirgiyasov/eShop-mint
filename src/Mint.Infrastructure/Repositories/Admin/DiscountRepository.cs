using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

internal sealed class DiscountRepository(ApplicationDbContext context)
    : GenericRepository<Discount>(context), IDiscountRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Discount?> GetDiscountByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var discount = await _context.Discounts.FirstOrDefaultAsync(
            x => x.ProductDiscounts!.Any(y => y.ProductId == productId),
            cancellationToken
        );

        return discount;
    }

    public async Task<List<Discount>> GetDiscountsByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var discounts = await _context.Discounts
            .OrderBy(x => x.ActiveDateUntil)
            .ToListAsync(cancellationToken);

        return discounts;
    }
}

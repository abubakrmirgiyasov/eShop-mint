using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Products;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

internal sealed class ProductRepository(ApplicationDbContext context)
    : GenericRepository<Product>(context), IProductRepository
{
    private readonly ApplicationDbContext _context = context;
    
    /// <inheritdoc/>
    public async Task<(List<Product>, int)> GetProductsAsync(Guid userId, string? searchPhrase = null, SortType sort = SortType.Ascending, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            query = query.Where(x =>
                x.ShortName.Contains(searchPhrase)
                || x.LongName.Contains(searchPhrase)
                || x.ShortDescription.Contains(searchPhrase)
                || x.FullDescription.Contains(searchPhrase)
            );

            if (sort == SortType.Ascending)
                query = query.OrderBy(x => x.ProductNumber);

            if (sort == SortType.Descending)
                query = query.OrderByDescending(x => x.ProductNumber);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var products = await query
            .AsNoTracking()
            .Include(x => x.ProductCategories!)
            .ThenInclude(x => x.Category)
            .Include(x => x.Manufacture)
            .Include(x => x.CommonCharacteristics)
            .Include(x => x.ProductCharacteristics)
            .Include(x => x.ProductPhotos!)
            .ThenInclude(x => x.Photo)
            .Where(x => x.Store!.UserId == userId)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (products, totalCount);
    }

    /// <inheritdoc/>
    public Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<Product> GetProductInfoAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken)
                ?? throw new NotFoundException("Товар не найден.");

        return product;
    }

    /// <inheritdoc/>
    public async Task<Product> GetProductWithCategoriesAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Include(x => x.ProductCategories)
            .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken)
                ?? throw new NotFoundException("Товар не найден.");

        return product;
    }
}

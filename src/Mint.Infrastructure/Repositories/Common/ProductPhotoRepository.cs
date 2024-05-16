using Microsoft.EntityFrameworkCore;
using Mint.Application.Repositories;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Repositories.Common;

/// <inheritdoc cref="IProductPhotoRepository"/>
internal sealed class ProductPhotoRepository(ApplicationDbContext context)
    : GenericRepository<ProductPhoto>(context), IProductPhotoRepository
{
    private readonly ApplicationDbContext _context = context;

    public Dictionary<Guid, List<Photo>> GetProductsImages(List<Guid> productsIds, int count = 5)
    {
        var photos = _context.ProductPhotos
            .Include(x => x.Photo)
            .Where(x => productsIds.Contains(x.ProductId!.Value))
            .GroupBy(x => x.ProductId!.Value)
            .ToDictionary(x => x.Key, x => x.Select(y => y.Photo!).Take(count).ToList());

        return photos;
    }
}

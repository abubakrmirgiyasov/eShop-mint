using Mint.Application.Interfaces;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Application.Repositories;

/// <summary>
/// Product Photo Repository
/// </summary>
public interface IProductPhotoRepository : IGenericRepository<ProductPhoto>
{
    /// <summary>
    /// Retrieves a Dictionary where Key is product id and Value is a Photos collection.
    /// </summary>
    /// <param name="productsIds"></param>
    /// <param name="count"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Dictionary<Guid, List<Photo>> GetProductsImages(List<Guid> productsIds, int count = 5);
}

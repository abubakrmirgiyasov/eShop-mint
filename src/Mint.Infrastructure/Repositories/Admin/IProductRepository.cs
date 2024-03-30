using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Repositories.Admin;

/// <summary>
/// Product repository Interface
/// </summary>
public interface IProductRepository : IBaseRepository<Product, Guid>
{

}

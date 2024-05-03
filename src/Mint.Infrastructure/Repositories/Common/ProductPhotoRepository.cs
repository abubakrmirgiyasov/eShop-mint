using Mint.Application.Repositories;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Repositories.Common;

/// <inheritdoc cref="IProductPhotoRepository"/>
internal sealed class ProductPhotoRepository(ApplicationDbContext context) 
    : GenericRepository<ProductPhoto>(context), IProductPhotoRepository;


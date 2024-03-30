using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Products;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories.Admin;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public ApplicationDbContext Context => context;

    public async Task<Product> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = Context.Products.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        var category = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundException("Категория не найдена");

        return category;
    }
}

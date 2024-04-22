using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Client.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Client;

/// <inheritdoc cref="IClientCategoryRepository"/>
internal sealed class ClientCategoryRepository(ApplicationDbContext context)
    : GenericRepository<Category>(context), IClientCategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc/>
    public async Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _context.Categories
            .AsNoTracking()
            .Include(x => x.SubCategories)
            .ToListAsync(cancellationToken);

        return categories;
    }
}

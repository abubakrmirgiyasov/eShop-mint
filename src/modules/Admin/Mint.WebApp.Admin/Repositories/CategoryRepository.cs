using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Repositories.Admin.Interfaces;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="ICategoryRepository"/>
public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public ApplicationDbContext Context => context;

    public async Task<List<Category>> GetCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default)
    {
        var query = Context.Categories.Where(x => x.DefaultLink != null).AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x => x.DefaultLink!.Contains(search));

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Category> FindByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        var category = await Context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellation)
            ?? throw new NotFoundException("Категория не найдена");

        return category;
    }

    public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await FindByIdAsync(id, cancellationToken);

        Context.Categories.Remove(category);
        await Context.SaveChangesAsync(cancellationToken);
    }
}

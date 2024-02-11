using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Repositories.Admin.Interfaces;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="ICategoryRepository"/>
public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public ApplicationDbContext Context => _context;

    public async Task<IEnumerable<Category>> GetCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(search))
            return await _context.Categories.ToListAsync(cancellationToken);

        var categories = await _context.Categories
            .Where(x => x.DefaultLink!.Contains(search))
            .ToListAsync(cancellationToken);
        return categories;
    }

    public async Task<Category> FindByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellation)
            ?? throw new NotFoundException("Категория не найдена");

        return category;
    }

    public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await FindByIdAsync(id, cancellationToken);

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="ICategoryRepository"/>
internal class CategoryRepository(
    ApplicationDbContext context
) : GenericRepository<Category>(context), ICategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc />
    public async Task<(List<Category>, int)> GetCategoriesAsync(string? searchPhrase = default, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default)
    {
        var query = _context.Categories
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
            query = query.Where(x => x.Name.Contains(searchPhrase));

        var totalCount = await query.CountAsync(cancellationToken);

        var categories = await query
            .Include(x => x.SubCategories)
            .Include(x => x.Photo)
            .Include(x => x.CategoryTags!)
            .ThenInclude(x => x.Tag)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (categories, totalCount);
    }

    /// <inheritdoc />
    public async Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .Include(x => x.SubCategories)
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new NotFoundException("Категория не найдена.");
         
        return category;
    }

    /// <inheritdoc />
    public async Task<List<Category>> GetCategoriesLinkAsync(string? searchPhrase = default, CancellationToken cancellationToken = default)
    {
        var query = _context.Categories
            .AsNoTracking()
            .Where(x => x.DefaultLink != null)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
            query = query.Where(x => x.DefaultLink!.Contains(searchPhrase));

        return await query.ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<List<Category>> GetCommonCategoriesAsync(string? searchPhrase = default, CancellationToken cancellationToken = default)
    {
        var query = _context.Categories.AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
            query = query.Where(x => x.Name.Contains(searchPhrase));

        var categories = await query
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return categories;
    }

    /// <inheritdoc />
    public async Task<Category> GetSampleCategoryById(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
               ?? throw new NotFoundException("Категория не найдена.");

        return category;
    }

    public async Task<Category?> GetCategoryWithPhotoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return category;
    }
}

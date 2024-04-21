using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="ISubCategoryRepository"/>
internal sealed class SubCategoryRepository(ApplicationDbContext context)
    : GenericRepository<SubCategory>(context), ISubCategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc/>
    public async Task<(List<SubCategory>, int)> GetSubCategoriesAsync(string? searchPhrase = null, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default)
    {
        var query = _context.SubCategories.AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
            query = query.Where(x => x.Name.Contains(searchPhrase));

        var totalCount = await query.CountAsync(cancellationToken);

        var subCategories = await query
            .AsNoTracking()
            .Include(x => x.Category)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (subCategories, totalCount);
    }

    /// <inheritdoc/>
    public async Task<List<string>> GetSubCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default)
    {
        var query = _context.SubCategories.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x => x.DefaultLink.Contains(search));

        return await query
            .Where(x => !string.IsNullOrEmpty(x.DefaultLink))
            .Select(x => x.DefaultLink!)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<SubCategory>> GetSimpleSubCategoriesAsync(string? search = default, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = _context.SubCategories.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x => x.Name.Contains(search));

        return await query.ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubCategory> GetSubCategoryInfoAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var subCategory = await _context.SubCategories
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new NotFoundException("Под категория не найдена.");

        return subCategory;
    }
}

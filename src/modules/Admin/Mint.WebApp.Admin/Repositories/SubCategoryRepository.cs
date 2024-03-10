using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Repositories;

/// <inheritdoc cref="ISubCategoryRepository"/>
public class SubCategoryRepository(ApplicationDbContext context) : ISubCategoryRepository
{
    /// <inheritdoc/>
    public ApplicationDbContext Context => context;

    /// <inheritdoc/>
    public async Task<IEnumerable<SubCategory>> GetSubCategoriesLinkAsync(string? search = null, CancellationToken cancellationToken = default)
    {
        var query = Context.SubCategories.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x => x.DefaultLink.Contains(search));

        return await query.ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubCategory> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = Context.SubCategories.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        var subCategory = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundException("Под категория не найдена");

        return subCategory;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var subCategory = await FindByIdAsync(id, cancellationToken: cancellationToken);

        Context.SubCategories.Remove(subCategory);
        await Context.SaveChangesAsync(cancellationToken);
    }  
}

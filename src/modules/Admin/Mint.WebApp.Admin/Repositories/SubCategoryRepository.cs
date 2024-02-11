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
    public Task<SubCategory> FindByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

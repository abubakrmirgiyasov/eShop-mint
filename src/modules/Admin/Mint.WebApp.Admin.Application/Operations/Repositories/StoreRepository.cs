using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Stores;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories.Admin;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

public class StoreRepository(ApplicationDbContext context) : IStoreRepository
{
    public ApplicationDbContext Context => context;

    public async Task<Store> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = Context.Stores.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        var store = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundException("Магазин не найден.");

        return store;
    }
}

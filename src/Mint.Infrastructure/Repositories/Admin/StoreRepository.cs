using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Stores;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

internal sealed class StoreRepository(ApplicationDbContext context)
    : GenericRepository<Store>(context), IStoreRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Store>> GetSampleStoreAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var stores = await _context.Stores
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);

        return stores;
    }
}

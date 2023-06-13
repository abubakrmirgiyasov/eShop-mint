using Mint.WebApp.Ordering.Interfaces;

namespace Mint.WebApp.Ordering.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDbContext _context;

    public UnitOfWork(IMongoDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        var changeAmount = await _context.SaveChangesAsync();
        return changeAmount > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

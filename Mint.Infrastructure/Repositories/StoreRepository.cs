using Microsoft.EntityFrameworkCore;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _context;

    public StoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<StoreFullViewModel> GetStoresAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<StoreFullViewModel> GetMyStoreAsync(Guid id)
    {
        try
        {
            var store = await _context.Stores
                .Include(x => x.Photo)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Error store");
            return new StoreManager().FormingViewModel(store);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}

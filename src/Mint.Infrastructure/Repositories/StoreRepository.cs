using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
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

    public async Task<List<StoreFullViewModel>> GetStoresAsync()
    {
        try
        {
            var stores = await _context.Stores
                .Include(x => x.Photo)
                .ToListAsync();
            return new StoreManager().FormingViewModels(stores);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<StoreFullViewModel> GetMyStoreAsync(Guid id)
    {
        try
        {
            var store = await _context.Stores
                .Include(x => x.Photo)
                .Include(x => x.Products)
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.User != null && x.User.Id == id)
                ?? throw new Exception("Error store");
            return new StoreManager().FormingViewModel(store);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<StoreFullViewModel> CreateStoreAsync(StoreFullBindingModel model)
    {
        try
        {
            var user = await _context.Users
                .Include(x => x.UserRoles)
                .Include(x => x.Stores)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(model.UserId!));

            if (user != null && user.Stores?.Count == 0)
            {
                var store = await new StoreManager().FormingBindingModel(model);

                var role = await _context.Roles
                    .FirstOrDefaultAsync(x => x.Name == Constants.SELLER)
                    ?? throw new Exception("Code[1020]: Что то пошло не так");

                var userRoles = await _context.UserRoles
                    .Where(x => x.UserId == user.Id)
                    .ToListAsync();

                var userRole = new UserRole()
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                };

                await _context.UserRoles.AddAsync(userRole);
                await _context.Stores.AddAsync(store);
                await _context.SaveChangesAsync();

                return new StoreManager().FormingViewModel(store);
            }
            else
            {

            }
            return null!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}

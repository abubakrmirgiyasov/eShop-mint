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
                .Include(x => x.StoreCategories!)
                .ThenInclude(x => x.Category)
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.User != null && x.User.Id == id)
                ?? throw new Exception("Создайте свой магазин, чтобы стать продавцом");
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
                .ToListAsync();

            var singleUser = user.FirstOrDefault(x => x.Id == Guid.Parse(model.UserId!));

            var isExistStore = await _context.Stores.ToListAsync();

            if (isExistStore.Any(x => x.Url.ToLower() ==  model.Url?.ToLower()))
                throw new Exception("Существует магазин по пути " + model.Url);

            if (singleUser != null && singleUser.Stores?.Count == 0)
            {
                var store = await new StoreManager().FormingBindingModel(model);

                var role = await _context.Roles
                    .FirstOrDefaultAsync(x => x.Name == Constants.SELLER)
                    ?? throw new Exception("Code[1020]: Что то пошло не так");

                var userRoles = await _context.UserRoles
                    .Where(x => x.UserId == singleUser.Id)
                    .ToListAsync();

                var userRole = new UserRole()
                {
                    UserId = singleUser.Id,
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
        catch (DbUpdateException ex) when (ex.InnerException != null && ex.InnerException.Message.StartsWith("Не удается вставить"))
        {
            throw new DbUpdateException("Указанный путь уже существует");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}

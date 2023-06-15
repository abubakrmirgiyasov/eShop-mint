using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class CommonRepository : ICommonRepository
{
    private readonly ApplicationDbContext _context;

    public CommonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MenuParentViewModel>> GetMenuAsync()
    {
        try
        {
            var menus = await _context.SubCategories
                .Include(x => x.Categories!)
                .ThenInclude(x => x.Photo!)
                .Include(x => x.Categories!.OrderBy(x => x.DisplayOrder))
                .ThenInclude(x => x.Manufacture)
                .ThenInclude(x => x!.Photo)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
            return new MenuManager().FormingModel(menus);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> SearchAsync(string query)
    {
        try
        {
            query = query.ToLower();

            var products = await _context.Products
               .Include(x => x.Discount)
               .Include(x => x.Manufacture)
               .Include(x => x.Category)
               .Include(x => x.CommonCharacteristics)
               .Include(x => x.Store)
               .Include(x => x.Storages)
               .Include(x => x.ProductPhotos!)
               .ThenInclude(x => x.Photo)
               .ToListAsync();

            products = products.Where(x => x.Name.ToLower().IndexOf(query) != -1 
                || x.FullDescription?.ToLower().IndexOf(query) != -1 
                || x.Category?.Name.ToLower().IndexOf(query) != -1)
                .ToList();

            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<LikeViewModel>> GetMyLikesAsync(Guid id)
    {
        try
        {
            var likes = await _context.LikedProducts
                .Include(x => x.Product)
                .ThenInclude(x => x!.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.UserId == id)
                .ToListAsync();
            return new LikeManager().FormingMultiViewModel(likes);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<LikeViewModel>> NewLikeAsync(LikeBindingModel model)
    {
        try
        {
            var myLikes = await _context.LikedProducts
                .Where(x => x.UserId == model.UserId)
                .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);

            if (myLikes == null)
            {
                var likes = new LikeManager().FormingBindingModel(model);
                
                await _context.LikedProducts.AddAsync(likes);
                await _context.SaveChangesAsync();

                return new LikeManager().FormingSingleViewModel(likes);
            }
            else
            {
                throw new Exception("Продукт уже существует.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task RemoveLike(LikeBindingModel model)
    {
        try
        {
            var myLikes = await _context.LikedProducts
                .Where(x => x.UserId == model.UserId)
                .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);

            if (myLikes != null)
            {
                _context.LikedProducts.Remove(myLikes);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Продукт уже существует.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductFullViewModel>> GetProductsAsync()
    {
        try
        {
            var products = await _context.Products
                .Where(x => x.IsPublished == true)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Include(x => x.Store)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.Discount)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetSellerProductsByIdAsync(Guid id)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.Store!.Id == id)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<ProductFullViewModel> GetProductByIdAsync(Guid id)
    {
        try
        {
            var product = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Продукт не найден");
            return new ProductManager().FormingSingleFullViewModel(product);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetSellerProductsByNameAsync(string name)
    {
        var product = await _context.Stores
            .Include(x => x.Products!)
            .ThenInclude(x => x.Discount)
            .Include(x => x.Products!)
            .ThenInclude(x => x.ProductPhotos!)
            .ThenInclude(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Url == name)
            ?? throw new Exception("Что то пошло не так.");
        return new ProductManager().FormingMultiViewModels(product);
    }

    public async Task<List<ProductFullViewModel>> GetProductsByCategoryAsync(string name)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.Category != null)
                .Where(x => x.Category!.DefaultLink == name)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetTopNewProductsAsync(int top)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.CreatedDate >= DateTime.Now.AddDays(-7))
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetTopDiscountedProductsAsync(int top)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.Discount != null)
                .Where(x => x.Discount!.Percent > 50)
                .Take(top)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetTopProductsAsync(int top)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Category)
                .Include(x => x.Store)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.Rating > 4)
                .Take(top)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetTopSaledProductsAsync(int top)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.Discount !=null && x.Discount.Percent > 15)
                .Take(top)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ProductFullViewModel>> GetTopSellersWithProductsAsync(int top)
    {
        try
        {
            var products = await _context.Products
                .Include(x => x.Discount)
                .Include(x => x.Manufacture)
                .Include(x => x.Category)
                .Include(x => x.CommonCharacteristics)
                .Include(x => x.Store)
                .Include(x => x.Storages)
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.CommonCharacteristics!.Count(x => x.Rate > 4.5) > 0)
                .Take(top)
                .ToListAsync();
            return new ProductManager().FormingFullProductViewModels(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task CreateProductAsync(ProductInfoBindingModel model)
    {
        try
        {
            var store = await _context.Stores
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(model.StoreId!))
                ?? throw new Exception("Выберете магазин или создайте новый.");

            var manager = new ProductManager();

            var product = manager.FormingInfoBindingModel(model);
            product.StoreId = store.Id;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateProductInfo(ProductInfoBindingModel model)
    {
        try
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == model.Id)
                ?? throw new Exception("Товар не найден.");

            product.Name = model.Name ?? product.Name;
            product.Sku = model.Sku ?? product.Sku;
            product.Gtin = model.Gtin == 0 ? product.Gtin : model.Gtin.ToString();
            product.CountryOfOrigin = model.CountryOfOrigin ?? product.CountryOfOrigin;
            product.IsPublished = product.IsPublished == model.IsPublished ? product.IsPublished : model.IsPublished;
            product.DeliveryMinDay = model.DeliveryMinDay == 1 ? product.DeliveryMinDay : model.DeliveryMinDay;
            product.DeliveryMaxDay = model.DeliveryMaxDay == 1 ? product.DeliveryMaxDay : model.DeliveryMaxDay;
            product.ShortDescription = model.ShortDescription ?? product.ShortDescription;
            product.FullDescription = model.FullDescription ?? product.FullDescription;
            product.AdminComment = model.AdminComment ?? product.AdminComment;
            //product.StoreId = model.StoreId == product.StoreId.ToString() ? product.StoreId : ;
            //product.Quantity

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateProductCharacteristicAsync(CommonCharacteristicFullBindingModel model)
    {
        try
        {
            var characteristic = await _context.CommonCharacteristics
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);

            if (characteristic == null)
            {
                var newCharacteristic = new CommonCharacteristic()
                {
                    Id = Guid.NewGuid(),
                    Material = model.Material,
                    Color = model.Color,
                    Garanty = model.Garanty,
                    Availability = model.Availability,
                    Weight = model.Weight,
                    Length = model.Length,
                    Width = model.Width,
                    Height = model.Height,
                    Rate = model.Rate,
                    ReleaseDate = model.ReleaseDate,
                    ProductId = model.ProductId,
                };
                await _context.CommonCharacteristics.AddAsync(newCharacteristic);
            }
            else
            {
                characteristic.Material = model.Material ?? characteristic.Material;
                characteristic.Color = model.Color ?? characteristic.Color;
                characteristic.Garanty = model.Garanty == characteristic.Garanty ? characteristic.Garanty : model.Garanty;
                characteristic.Availability = model.Availability;
                characteristic.Weight = model.Weight == characteristic.Weight ? characteristic.Weight : model.Weight;
                characteristic.Length = model.Length == characteristic.Length ? characteristic.Length : model.Length;
                characteristic.Width = model.Width == characteristic.Width ? characteristic.Weight : model.Width;
                characteristic.Height = model.Height == characteristic.Height ? characteristic.Weight : model.Height;
                characteristic.Rate = model.Rate == characteristic.Rate ? characteristic.Weight : model.Rate;
                characteristic.ReleaseDate = model.ReleaseDate == characteristic.ReleaseDate ? characteristic.ReleaseDate : model.ReleaseDate;
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateProductPriceAsync(ProductPriceBindingModel model)
    {
        try
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == model.ProductId)
                ?? throw new Exception("Товар не найден.");

            product.Price = model.Price == product.Price ? product.Price : model.Price;

            if (model.IsFreeTax != null)
            {
                product.IsFreeTax = bool.Parse(model.IsFreeTax);
                product.TaxPrice = model.TaxPrice;
            } 
            else
            {
                product.IsFreeTax = false;
                product.TaxPrice = model.TaxPrice;
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateProductPicturesAsync(ProductPicturesBindingModel model)
    {
        try
        {
            var product = await _context.Products
                .Include(x => x.ProductPhotos)
                .Include(x => x.Store)
                .FirstOrDefaultAsync(x => x.Id == model.ProductId)
            ?? throw new Exception("Товар не найден.");

            var list = new List<ProductPhoto>();

            if (product.ProductPhotos?.Count == 0)
            {
                for (int i = 0; i < model.Files?.Count; i++)
                {
                    list.Add(new ProductPhoto()
                    {
                        Product = product,
                        Photo = await PhotoManager.CopyPhotoAsync(model.Files[i], product.Id, "products/" + product.Store?.Id),
                    });
                }
            }
            else
            {

            }

            await _context.ProductPhotos.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task CategoryMappingsAsync(ProductCategoryMappingsBindingModel model)
    {
        try
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == model.ProductId)
                ?? throw new Exception("Товар не найден.");

            product.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task ManufactureMappingsAsync(ProductManufactureMappingsBindingModel model)
    {
        try
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == model.ProductId)
                ?? throw new Exception("Товар не найден.");

            product.ManufactureId = model.ManufactureId;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task PromotionsAsync(ProductPromotionsBindingModel model)
    {
        try
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == model.ProductId)
                ?? throw new Exception("Товар не найден.");

            product.DiscountId = model.PromotionId;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteProductAsync(Guid id)
    {
        try
        {
            var product = await _context.Products
                .Include(x => x.ProductPhotos!)
                .ThenInclude(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Товар не найден.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            for (int i = 0; i < product.ProductPhotos?.Count; i++)
            {
                if (product.ProductPhotos[i].Photo != null)
                {
                    _context.ProductPhotos.RemoveRange(product.ProductPhotos);
                    await _context.SaveChangesAsync();

                    PhotoManager.DeletePhoto(product.ProductPhotos[i].Photo?.FilePath);
                }
            }
        }
        catch (Exception ex)
        {
            // roll back ?
            throw new Exception(ex.Message, ex);
        }
    }
}

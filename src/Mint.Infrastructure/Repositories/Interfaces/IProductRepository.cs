using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<ProductFullViewModel>> GetProductsAsync();

    Task<List<ProductFullViewModel>> GetSellerProductsByIdAsync(Guid id);

    Task<ProductFullViewModel> GetProductByIdAsync(Guid id);

    Task<List<ProductFullViewModel>> GetSellerProductsByNameAsync(string name);

    Task<List<ProductFullViewModel>> GetProductsByCategoryAsync(string name);

    Task<List<ProductFullViewModel>> GetTopProductsAsync(int top);

    Task<List<ProductFullViewModel>> GetTopSaledProductsAsync(int top);

    Task<List<ProductFullViewModel>> GetTopDiscountedProductsAsync(int top);

    Task<List<ProductFullViewModel>> GetTopSellersWithProductsAsync(int top);

    Task CreateProductAsync(ProductInfoBindingModel model);

    Task UpdateProductInfo(ProductInfoBindingModel model);

    Task UpdateProductCharacteristicAsync(CommonCharacteristicFullBindingModel model);

    Task UpdateProductPriceAsync(ProductPriceBindingModel model);

    Task UpdateProductPicturesAsync(ProductPicturesBindingModel model);

    Task CategoryMappingsAsync(ProductCategoryMappingsBindingModel model);

    Task ManufactureMappingsAsync(ProductManufactureMappingsBindingModel model);

    Task PromotionsAsync(ProductPromotionsBindingModel model);

    Task DeleteProductAsync(Guid id);
    Task<List<ProductFullViewModel>> GetTopNewProductsAsync(int top);
}

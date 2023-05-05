using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<ProductFullViewModel>> GetProductsAsync();

    Task<List<ProductFullViewModel>> GetSellerProductsAsync(Guid id);

    Task<ProductFullViewModel> GetProductByIdAsync(Guid id);

    Task<List<ProductFullViewModel>> GetTopProductsAsync(int top);

    Task<List<ProductFullViewModel>> GetTopSaledProductsAsync(int top);

    Task<List<ProductFullViewModel>> GetTopDiscountedProductsAsync(int top);

    Task<List<ProductFullViewModel>> GetTopSellersWithProductsAsync(int top);

    Task<ProductFullViewModel> CreateProductAsync(ProductInfoBindingModel model);

    Task UpdateProductCharacteristicAsync(CommonCharacteristicFullBindingModel model);

    Task UpdateProductPriceAsync(ProductPriceBindingModel model);

    Task UpdateProductPicturesAsync(ProductPicturesBindingModel model);

    Task CategoryMappingsAsync(ProductCategoryMappingsBindingModel model);

    Task ManufactureMappingsAsync(ProductManufactureMappingsBindingModel model);

    Task PromotionsAsync(ProductPromotionsBindingModel model);

    Task<ProductFullViewModel> DeleteProductAsync(Guid id);
}

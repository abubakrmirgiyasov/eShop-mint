using Mint.Domain.ViewModels;
using Mint.MAUI.App.Services;

namespace Mint.MAUI.App.Middlewares;

public interface IProductService
{
    Task<List<ProductFullViewModel>> GetProductsAsync();
}

public class ProductService : IProductService
{
    public async Task<List<ProductFullViewModel>> GetProductsAsync()
    {
        var request = new Request<List<ProductFullViewModel>>(false);
        return await request.GetRequestAsync("api/product/gettopptoducts/6");
    }
}

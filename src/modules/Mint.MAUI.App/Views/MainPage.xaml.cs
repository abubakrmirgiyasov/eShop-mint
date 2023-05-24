using Mint.MAUI.App.Middlewares;

namespace Mint.MAUI.App;

public partial class MainPage : ContentPage
{
    private readonly IProductService _product;

    public MainPage()
    {
        InitializeComponent();
    }

    public MainPage(IProductService product)
    {
        _product = product;
    }

    private async void OnLoaded(object sender, EventArgs e)
    {
        var c = await _product.GetProductsAsync();
    }
}
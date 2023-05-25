using Mint.MAUI.App.Middlewares;

namespace Mint.MAUI.App;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLoaded(object sender, EventArgs e)
    {
        var p = new ProductService();

        var x = await p.GetProductsAsync();
    }
}
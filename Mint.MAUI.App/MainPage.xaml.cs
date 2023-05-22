using Mint.MAUI.App.Middlewares;

namespace Mint.MAUI.App;

public partial class MainPage : ContentPage
{
    int count = 0;

    private readonly IProductService _product;

    public MainPage()
    {
        InitializeComponent();
    }

    public MainPage(IProductService product)
    {
        _product = product;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        var c = await _product.GetProductsAsync();

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
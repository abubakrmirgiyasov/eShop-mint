using CommunityToolkit.Maui.Views;
using Mint.Domain.FormingModels;
using Mint.MAUI.App.Components;
using Mint.MAUI.App.Middlewares;

namespace Mint.MAUI.App.Views.Footer;

public partial class Home : ContentView
{
	private readonly ProductService _product;

	public Home()
	{
        InitializeComponent();

		_product = new ProductService();
		//Application.Current.UserAppTheme = AppTheme.Dark;
	}

    private async void OnLoaded(object sender, EventArgs e)
    {
		try
		{
            bool isLoading = true;

            //var loader = new Loader();

            //this.ShowPopup(loader);

            //var products = await _product.GetProductsAsync();

            //loader.Close();

            isLoading = false;
        }
		catch (Exception ex)
		{
			//await DisplayAlert("Œ¯Ë·Í‡", ex.Message, "Œ ");
		}
    }

	private void FillRow()
	{
		try
		{

		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
using Mint.MAUI.App.Middlewares;

namespace Mint.MAUI.App.Extensions;

public static class RegisterAppServicesExtensions
{
    public static MauiAppBuilder RegisterTransientServices(this MauiAppBuilder builder)
    {
        return builder;
    }

    public static MauiAppBuilder RegisterScopedServices(this MauiAppBuilder builder)
    {
        builder.Services.AddScoped<IProductService, ProductService>();

        return builder;
    }

    public static MauiAppBuilder RegisterSingletonServices(this MauiAppBuilder builder)
    {
        return builder;
    }
}

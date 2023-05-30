namespace Mint.MAUI.App.Services;

internal class Singleton
{
    private static Singleton _instance;

    internal bool IsLoading { get; private set; }

    internal Singleton(bool isLoading)
    {
        IsLoading = isLoading;
    }

    internal static Singleton Instance(bool isLoading) 
        => _instance ??= new Singleton(isLoading);
}

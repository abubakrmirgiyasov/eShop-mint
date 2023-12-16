using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mint.WebApp.Extensions.Configurations;

public static class AppSettingsExtensions
{
    public static IServiceCollection ConfigureAppSettings<T>(this IServiceCollection services, IConfiguration configuration, string name)
    {
        //var settings = configuration.GetSection(name);
        //services.Configure<T>(settings);

        return services;
    }
}

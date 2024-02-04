using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure.Helpers;
using Mint.Infrastructure.Services.Interfaces;
using Mint.Infrastructure.Services;

namespace Mint.WebApp.Extensions.Infrastructures;

public static class MinioExtensions
{
    public static IServiceCollection AddMinioServices(this IServiceCollection services)
    {
        services.AddScoped<MinioClientConnection>();
        services.AddScoped<IStorageCloudService, StorageCloudService>();

        return services;
    }
}

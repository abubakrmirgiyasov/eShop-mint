using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Redis;

namespace Mint.WebApp.Extensions.Infrastructures;

public static class RedisEstensions
{
    public static IServiceCollection RedisServices(this IServiceCollection services)
    {
        services.AddScoped<IDistributedCacheManager, RedisCacheManager>();

        return services;
    }
}

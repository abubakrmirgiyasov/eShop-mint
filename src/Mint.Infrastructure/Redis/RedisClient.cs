using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using StackExchange.Redis;
using System.Security.Authentication;

namespace Mint.Infrastructure.Redis;

public class RedisClient
{
    public RedisCache RedisCache;

    private readonly RedisSettings _redis;

    public RedisClient(IOptions<RedisSettings> redis)
    {
        _redis = redis.Value;

        var redisOptions = new RedisCacheOptions()
        {
            ConfigurationOptions = new ConfigurationOptions()
            {
                Ssl = true,
                SslProtocols = SslProtocols.Tls12,
                AbortOnConnectFail = false,
                EndPoints = { { _redis.Host, _redis.Port } }
            }
        };
        var options = Options.Create(redisOptions);
        RedisCache = new RedisCache(options);
    }
}

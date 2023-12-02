using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using StackExchange.Redis;
using System.Security.Authentication;

namespace Mint.Infrastructure.Redis;

public class RedisClient(IOptions<RedisSettings> redis)
{
    private readonly RedisSettings _redis = redis.Value;

    public IDatabase RedisCache
    {
        get
        {
            var redisConnection = ConnectionMultiplexer.Connect($"{_redis.Host}:{_redis.Port}");
            return redisConnection.GetDatabase();
        }
    }
}
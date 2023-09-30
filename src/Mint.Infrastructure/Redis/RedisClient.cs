using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using StackExchange.Redis;
using System.Security.Authentication;

namespace Mint.Infrastructure.Redis;

public class RedisClient
{
    private readonly RedisSettings _redis;

    public RedisClient(IOptions<RedisSettings> redis)
    {
        _redis = redis.Value;
    }

    public IDatabase RedisCache
    {
        get
        {
            var redisConnection = ConnectionMultiplexer.Connect($"{_redis.Host}:{_redis.Port}");
            return redisConnection.GetDatabase();
        }
    }
}
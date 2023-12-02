﻿using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using StackExchange.Redis;
using System.Security.Authentication;

namespace Mint.Infrastructure.Redis;

public class RedisClient(IOptions<AppSettings> redis)
{
    private readonly AppSettings _redis = redis.Value;

    public IDatabase RedisCache
    {
        get
        {
            var redisConnection = ConnectionMultiplexer.Connect($"{_redis.RedisSettings.Host}:{_redis.RedisSettings.Port}");
            return redisConnection.GetDatabase();
        }
    }
}
using Microsoft.Extensions.Caching.Distributed;
using Mint.Infrastructure.Redis.Interface;
using Newtonsoft.Json;
using System.Text;

namespace Mint.Infrastructure.Redis;

public class RedisCacheManager : IDistributedCacheManager
{
    private readonly RedisClient _redisClient;

    public RedisCacheManager(RedisClient redisClient)
    {
        _redisClient = redisClient;
    }

    public byte[] Get(string key)
    {
        return _redisClient.RedisCache.Get(key)!;
    }

    public T Get<T>(string key)
    {
        var utf8 = Encoding.UTF8.GetString(Get(key));
        return JsonConvert.DeserializeObject<T>(utf8);
    }

    public void Set<T>(string key, T value)
    {
        var serialized = JsonConvert.SerializeObject(value);
        _redisClient.RedisCache.SetString(key, serialized, new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60),
            SlidingExpiration = TimeSpan.FromSeconds(30),
        });
    }

    public bool Any(string key)
    {
        return _redisClient.RedisCache.Get(key) != null;
    }

    public void Refresh(string key)
    {
        _redisClient.RedisCache.Refresh(key);
    }

    public void Remove(string key)
    {
        _redisClient.RedisCache.Remove(key);
    }
}

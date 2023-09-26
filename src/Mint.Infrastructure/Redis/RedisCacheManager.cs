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
        var isKeyExist = _redisClient.RedisCache.KeyExists(key);

        if (isKeyExist)
            return _redisClient.RedisCache.StringGet(key)!;

        return null!;
    }

    public T Get<T>(string key)
    {
        var utf8 = Encoding.UTF8.GetString(Get(key));

        if (utf8 is null)
            return default!;

        return JsonConvert.DeserializeObject<T>(utf8);
    }

    public void Set<T>(string key, T value)
    {
        var serialized = JsonConvert.SerializeObject(value);
        _redisClient.RedisCache.StringSet(key, serialized);
    }

    public bool Exists(string key)
    {
        return _redisClient.RedisCache.KeyExists(key);
    }

    public void Refresh(string key)
    {
        //_redisClient.RedisCache.Up.Refresh(key);
    }

    public void Remove(string key)
    {
        _redisClient.RedisCache.KeyDelete(key);
    }
}

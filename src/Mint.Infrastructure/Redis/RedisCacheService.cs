using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using Mint.Domain.Extensions;
using Mint.Infrastructure.Redis.Interface;
using Newtonsoft.Json;
using System.Text;

namespace Mint.Infrastructure.Redis;

public class RedisCacheService(IOptions<AppSettings> appSettings) : IRedisCacheService
{
    private readonly RedisClient _redisClient = new(appSettings);

    public byte[] Get(string key)
    {
        bool isKeyExist = _redisClient.RedisCache.KeyExists(key);

        if (isKeyExist)
            return _redisClient.RedisCache.StringGet(key)!;

        return null!;
    }

    public T Get<T>(string key)
    {
        byte[]? data = Get(key);

        if (data is null)
            return default!;

        var utf8 = Encoding.UTF8.GetString(data);

        return JsonConvert.DeserializeObject<T>(utf8)!;
    }

    public void Set<T>(string key, T value)
    {
        var serialized = JsonConvert.SerializeObject(value);
        _redisClient.RedisCache.StringSet(key, serialized);
    }

    public bool Exists(string key)
    {
        if (key.IsNullOrEmpty())
            return false;
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

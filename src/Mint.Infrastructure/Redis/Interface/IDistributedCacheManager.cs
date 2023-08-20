﻿namespace Mint.Infrastructure.Redis.Interface;

/// <summary>
/// 
/// </summary>
public interface IDistributedCacheManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    byte[] Get(string key);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    T Get<T>(string key);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set<T>(string key, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    void Refresh(string key);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Any(string key);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    void Remove(string key);
}

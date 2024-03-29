﻿namespace Mint.Infrastructure.Repositories;

/// <summary>
/// Base repository
/// </summary>
/// <typeparam name="TModel">Model</typeparam>
/// <typeparam name="TKey">Type of key</typeparam>
public interface IBaseRepository<TModel, TKey>
{
    /// <summary>
    /// Application db base context
    /// </summary>
    ApplicationDbContext Context { get; }

    /// <summary>
    /// Filtering by first or default value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotFoundException"></exception>
    /// <exception cref="Exception"></exception>
    /// <returns></returns>
    Task<TModel> FindByIdAsync(TKey id, bool asNoTracking = false, CancellationToken cancellationToken = default);
}

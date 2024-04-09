using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Store Repository
/// </summary>
public interface IStoreRepository : IGenericRepository<Store>
{
    /// <summary>
    /// Retrieves a sample store
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Store>> GetSampleStoreAsync(Guid id, CancellationToken cancellationToken = default);
}
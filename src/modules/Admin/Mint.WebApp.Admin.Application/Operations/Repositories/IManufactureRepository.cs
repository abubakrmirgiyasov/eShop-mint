using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Manufactures;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
/// Manufacture Repository
/// </summary>
public interface IManufactureRepository : IGenericRepository<Manufacture>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchPhrase"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(List<Manufacture>, int)> GetManufacturesAsync(string? searchPhrase, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Manufacture> GetManufactureByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Manufacture?> GetManufactureWithPhotoAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Manufacture?> GetManufactureWithContacts(Guid id, CancellationToken cancellationToken = default);
}

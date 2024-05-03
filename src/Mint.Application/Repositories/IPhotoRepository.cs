using Mint.Application.Interfaces;
using Mint.Domain.Models;
using System.Linq.Expressions;

namespace Mint.Application.Repositories;

/// <summary>
/// Photo Repository
/// </summary>
public interface IPhotoRepository : IGenericRepository<Photo>
{
    /// <summary>
    /// Retrieves a single photo by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Photo> GetPhotoById(Expression<Func<Photo, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection photos by item id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Photo>> GetPhotosById(Expression<Func<Photo, bool>> predicate, CancellationToken cancellationToken = default);
}

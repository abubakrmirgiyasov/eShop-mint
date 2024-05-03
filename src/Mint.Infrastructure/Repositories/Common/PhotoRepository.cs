using Mint.Application.Repositories;
using Mint.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mint.Infrastructure.Repositories.Common;

internal sealed class PhotoRepository(ApplicationDbContext context) : GenericRepository<Photo>(context), IPhotoRepository
{
    private readonly ApplicationDbContext _context = context;

    public Task<Photo> GetPhotoById(Expression<Func<Photo, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Photo>> GetPhotosById(Expression<Func<Photo, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var photos = await _context.Photos
            .Where(predicate)
            .ToListAsync(cancellationToken);

        return photos;
    }
}

using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="IManufactureRepository" />
internal sealed class ManufactureRepository(ApplicationDbContext context)
    : GenericRepository<Manufacture>(context), IManufactureRepository
{
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc/>
    public async Task<(List<Manufacture>, int)> GetManufacturesAsync(string? searchPhrase, int pageIndex = 0, int pageSize = 0, CancellationToken cancellationToken = default)
    {
        var query = _context.Manufactures
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            query = query.Where(x =>
                x.Name.Contains(searchPhrase) ||
                x.Description!.Contains(searchPhrase) ||
                x.Website!.Contains(searchPhrase)
            );
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var manufactures = await query
            .Include(x => x.Contacts)
            .Include(x => x.ManufactureTags!)
            .ThenInclude(x => x.Tag)
            .Include(x => x.ManufactureCategories!)
            .ThenInclude(x => x.Category)
            .Include(x => x.Photo)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        return (manufactures, totalCount);
    }

    /// <inheritdoc/>
    public async Task<Manufacture> GetManufactureByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var manufacture = await _context.Manufactures
            .AsNoTracking()
            .Include(x => x.Photo)
            .Include(x => x.Contacts)
            .Include(x => x.ManufactureCategories!)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new NotFoundException("Производитель не найден.");

        return manufacture;
    }

    /// <inheritdoc/>
    public async Task<Manufacture?> GetManufactureWithPhotoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var manufacture = await _context.Manufactures
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return manufacture;
    }

    /// <inheritdoc/>
    public async Task<Manufacture?> GetManufactureWithContacts(Guid id, CancellationToken cancellationToken = default)
    {
        var manufacture = await _context.Manufactures
            .Include(x => x.Contacts)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return manufacture;
    }
}

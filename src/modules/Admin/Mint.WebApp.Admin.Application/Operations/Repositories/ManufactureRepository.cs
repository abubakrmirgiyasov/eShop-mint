using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories.Admin;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

public class ManufactureRepository(ApplicationDbContext context) : IManufactureRepository
{
    public ApplicationDbContext Context => context;

    public async Task<Manufacture> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = Context.Manufactures.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        var manufacture = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundException("Производитель не найден.");

        return manufacture;
    }
}

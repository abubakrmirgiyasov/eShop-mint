using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories.Admin;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <inheritdoc cref="ITagRepository"/>
public class TagRepository(ApplicationDbContext context) : ITagRepository
{
    public ApplicationDbContext Context => context;

    /// <inheritdoc />
    public async Task<List<Tag>> GetTagsAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Tags.ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Tag> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var query = Context.Tags.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        var tag = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundException($"Атрибут c Id={id} не найден.");

        return tag;
    }

    /// <inheritdoc />
    public async Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await Context.Tags.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(id), "Атрибут не найден");

            Context.Tags.Remove(tag);
            await Context.SaveChangesAsync(cancellationToken);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}

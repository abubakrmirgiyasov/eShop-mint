using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Tags;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="ITagRepository"/>
internal sealed class TagRepository(ApplicationDbContext context)
    : GenericRepository<Tag>(context), ITagRepository
{
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc />
    public async Task<(List<Tag>, int)> GetTagsAsync(string? searchPhrase = null, int pageIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default)
    {
        var query = _context.Tags.AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            query = query.Where(x =>
                x.Name.Contains(searchPhrase)
                || x.Translate!.Contains(searchPhrase)
            );
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var tags = await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (tags, totalCount);
    }
}

//
//public async Task<List<Tag>> GetTagsAsync(CancellationToken cancellationToken = default)
//{
//    return await Context.Tags.ToListAsync(cancellationToken);
//}

///// <inheritdoc />
//public async Task<Tag> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
//{
//    var query = Context.Tags.AsQueryable();

//    if (asNoTracking)
//        query = query.AsNoTracking();

//    var tag = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
//        ?? throw new NotFoundException($"Атрибут c Id={id} не найден.");

//    return tag;
//}

///// <inheritdoc />
//public async Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default)
//{
//    try
//    {
//        var tag = await Context.Tags.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
//            ?? throw new ArgumentNullException(nameof(id), "Атрибут не найден");

//        Context.Tags.Remove(tag);
//        await Context.SaveChangesAsync(cancellationToken);
//    }
//    catch (ArgumentNullException ex)
//    {
//        throw new ArgumentNullException(ex.Message, ex);
//    }
//    catch (Exception ex)
//    {
//        throw new Exception(ex.Message, ex);
//    }
//}

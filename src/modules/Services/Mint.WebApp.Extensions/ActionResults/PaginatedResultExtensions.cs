using Microsoft.EntityFrameworkCore;
using Mint.Domain.Helpers;

namespace Mint.WebApp.Extensions.ActionResults;

public static class PaginatedResultExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedResult<T>(
        this IQueryable<T> query,
        int pageIndex,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        if (query is null)
            throw new ArgumentNullException(nameof(query));

        if (pageIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(pageIndex));

        if (pageSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(pageSize));

        var totalCount = await query.LongCountAsync(cancellationToken);
        var items = await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<T>(items, totalCount);
    }
}

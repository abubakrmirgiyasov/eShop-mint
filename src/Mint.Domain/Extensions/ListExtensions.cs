using Mint.Domain.Common;

namespace Mint.Domain.Extensions;

public static class ListExtensions
{
    public static IOrderedEnumerable<TSource> SortBy<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        SortType sort)
    {
        if (sort == SortType.Descending)
            return source.OrderByDescending(keySelector);
        else
            return source.OrderBy(keySelector);
    }
}

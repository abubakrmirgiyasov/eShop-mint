using Mint.Domain.Common;
using System.ComponentModel;

namespace Mint.Domain.Extensions;

public static class ListExtensions
{
    public static IOrderedEnumerable<T> SortBy<T>(
        this IEnumerable<T> source,
        Func<T, object?> propertyExpression,
        SortDirection sortDir) where T : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(propertyExpression);

        if (!Enum.IsDefined(typeof(SortDirection), sortDir))
            throw new InvalidEnumArgumentException(nameof(sortDir), (int)sortDir, typeof(SortDirection));


        if (sortDir is SortDirection.Descending)
            return source.OrderByDescending(propertyExpression);
        else
            return source.OrderBy(propertyExpression);
    }
}

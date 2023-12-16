namespace Mint.Domain.Helpers;

public class PaginatedResult<T>
{
    public PaginatedResult() { }

    public PaginatedResult(List<T> items, long totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }

    public PaginatedResult(IEnumerable<T> items, long totalCount)
        : this(items.ToList(), totalCount) { }

    public List<T> Items { get; set; } = [];

    public long TotalCount { get; set; } = 0;
}

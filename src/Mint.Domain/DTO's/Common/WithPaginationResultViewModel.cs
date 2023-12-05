namespace Mint.Domain.DTO_s.Common;

public class WithPaginationResultViewModel<T>
{
    public T Items { get; set; } = default!;

    public int TotalCount { get; set; }
}

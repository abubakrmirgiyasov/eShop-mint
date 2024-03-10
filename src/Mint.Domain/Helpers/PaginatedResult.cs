namespace Mint.Domain.Helpers;

/// <summary>
/// Модель представляющая результат постраничной загрузки.
/// </summary>
/// <typeparam name="T">Тип загруженное сущности.</typeparam>
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

    /// <summary>
    /// Список элементов на текущей странице.
    /// </summary>
    public List<T> Items { get; set; } = [];

    /// <summary>
    /// Общее количество загруженных элементов.
    /// </summary>
    public long TotalCount { get; set; } = 0;
}

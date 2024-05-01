namespace Mint.Application.Interfaces;

/// <summary>
/// Общий репозиторий для сущности типа <typeparamref name="T"></typeparamref>.
/// </summary>
/// <typeparam name="T">Тип сущности, с которым работает данный репозиторий.</typeparam>
public interface IGenericRepository<T> : IGenericReadRepository<T> where T : class
{
    /// <summary>
    /// Добавляет указанную сущность в базу данных.
    /// </summary>
    /// <param name="entity">Добавляемая сущность.</param>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавляет указанные сущности в базу данных.
    /// </summary>
    /// <param name="entities">Добавляемые сущности.</param>
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет указанную сущность в базе данных.
    /// </summary>
    /// <param name="entity">Обновляемая сущность.</param>
    void Update(T entity);

    /// <summary>
    /// Обновляет указанные сущности в базе данных.
    /// </summary>
    /// <param name="entities">Обновляемые сущности.</param>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Удаляет указанную сущность из базы данных.
    /// </summary>
    /// <param name="entity">Удаляемая сущность.</param>
    void Remove(T entity);

    /// <summary>
    /// Удаляет указанные сущности из базы данных.
    /// </summary>
    /// <param name="entities">Удаляемые сущности.</param>
    void RemoveRange(IEnumerable<T> entities);
}

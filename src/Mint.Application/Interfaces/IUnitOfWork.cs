namespace Mint.Application.Interfaces;

/// <summary>
/// Единица работы с базой данных Mint.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Асинхронно создает транзакцию базы данных.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Объект представляющий созданную транзакцию <see cref="ITransaction"/>.</returns>
    Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Сохраняет изменения.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Количество измененных строк в базе данных.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

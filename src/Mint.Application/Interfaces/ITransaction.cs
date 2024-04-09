namespace Mint.Application.Interfaces;

/// <summary>
/// Представляет абстракцию над транзакцией базы данных.
/// </summary>
public interface ITransaction
{
    /// <summary>
    /// Завершает транзакцию с успехом.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Откатывает изменения транзакции.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RollbackAsync(CancellationToken cancellationToken = default);
}

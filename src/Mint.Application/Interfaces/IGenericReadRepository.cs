using System.Linq.Expressions;

namespace Mint.Application.Interfaces;

/// <summary>
/// Общий репозиторий для чтения сущности типа <typeparamref name="T"></typeparamref>.
/// </summary>
/// <typeparam name="T">Тип сущности, с которым работает данный репозиторий.</typeparam>
public interface IGenericReadRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default);

    Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default);
}

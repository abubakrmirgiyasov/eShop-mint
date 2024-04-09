using Microsoft.EntityFrameworkCore.Storage;
using Mint.Application.Interfaces;

namespace Mint.Infrastructure.Helpers;

/// <summary>
/// Реализация транзакции для EF Core.
/// </summary>
internal sealed class EfCoreTransactionProxy(IDbContextTransaction transaction) : ITransaction
{
    private readonly IDbContextTransaction _transaction = transaction;

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _transaction.CommitAsync(cancellationToken);
    }

    public Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        return _transaction.RollbackAsync(cancellationToken);
    }

    public void Dispose()
    {
        _transaction.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _transaction.DisposeAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using Mint.Application.Interfaces;
using System.Linq.Expressions;

namespace Mint.Infrastructure.Repositories;

/// <inheritdoc cref="IGenericRepository{T}"/>
internal class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _dbSet.ToListAsync(cancellationToken);
    }

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(func, cancellationToken);
    }
    
    public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default)
    {
        return _dbSet.SingleOrDefaultAsync(func, cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default)
    {
        return _dbSet.AnyAsync(func, cancellationToken);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return _dbSet.CountAsync(cancellationToken);
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> func, CancellationToken cancellationToken = default)
    {
        return _dbSet.CountAsync(func, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}

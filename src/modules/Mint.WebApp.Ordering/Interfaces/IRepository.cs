namespace Mint.WebApp.Ordering.Interfaces;

public interface IRepository<TEntity, TKey> : IDisposable 
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(TKey key);
        
    TEntity Add(TEntity entity);

    TEntity Update(TEntity entity);

    void Delete(TKey key);
}

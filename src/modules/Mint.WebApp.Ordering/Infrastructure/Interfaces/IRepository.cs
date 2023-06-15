using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : IDocument
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(Guid key);

    TEntity Add(TEntity entity);

    TEntity Update(TEntity entity);

    void Delete(Guid key);
}

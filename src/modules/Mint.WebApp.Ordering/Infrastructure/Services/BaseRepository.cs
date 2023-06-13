using Mint.WebApp.Ordering.Interfaces;
using MongoDB.Driver;
using ServiceStack;

namespace Mint.WebApp.Ordering.Infrastructure.Services;

public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly IMongoDbContext Context;
    protected IMongoCollection<TEntity> DbSet;

    public BaseRepository(IMongoDbContext context)
    {
        Context = context;
        DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
        return all.ToList();
    }

    public virtual async Task<TEntity> GetByIdAsync(TKey key)
    {
        var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", key));
        return data.SingleOrDefault();
    }

    public virtual TEntity Add(TEntity entity)
    {
        Context.AddCommand(() => DbSet.InsertOneAsync(entity));
        return entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity));
        return entity;
    }

    public virtual void Delete(TKey key)
    {
        Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", key)));
    }

    public void Dispose()
    {
        Context?.Dispose();
    }
}

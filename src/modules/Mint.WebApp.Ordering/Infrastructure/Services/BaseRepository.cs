#nullable disable

using Mint.WebApp.Ordering.Attributes;
using Mint.WebApp.Ordering.Common;
using Mint.WebApp.Ordering.Infrastructure.Interfaces;
using Mint.WebApp.Ordering.Models;
using MongoDB.Driver;
using ServiceStack;

namespace Mint.WebApp.Ordering.Infrastructure.Services;

public class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : IDocument
{
    private readonly IMongoCollection<TEntity> _collection;

    public BaseRepository(IMongoDbSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
    }

    private protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
            typeof(BsonCollectionAttribute),
            true)
            .FirstOrDefault())?.CollectionName;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _collection.AsQueryable().ToListAsync();
    }

    public Task<TEntity> GetByIdAsync(Guid key)
    {
        throw new NotImplementedException();
    }

    public TEntity Add(TEntity entity)
    {
        _collection.InsertOne(entity);
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid key)
    {
        throw new NotImplementedException();
    }
}

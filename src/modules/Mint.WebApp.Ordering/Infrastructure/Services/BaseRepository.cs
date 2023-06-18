#nullable disable

using Mint.WebApp.Ordering.Attributes;
using Mint.WebApp.Ordering.Common;
using Mint.WebApp.Ordering.Infrastructure.Interfaces;
using Mint.WebApp.Ordering.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

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

    public virtual IQueryable<TEntity> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    public virtual IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filterExpression)
    {
        return _collection
            .Find(filterExpression)
            .ToEnumerable();
    }

    public virtual IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TEntity, bool>> filterExpression, 
        Expression<Func<TEntity, TProjected>> projectedExpression)
    {
        return _collection
            .Find(filterExpression)
            .Project(projectedExpression)
            .ToEnumerable();
    }

    public virtual TEntity FindById(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, objectId);
        return _collection.Find(filter).SingleOrDefault();
    }

    public virtual async Task<TEntity> FindByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, objectId);
        return await _collection.Find(filter).SingleOrDefaultAsync();
    }

    public virtual TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).FirstOrDefault();
    }

    public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return await _collection.Find(filterExpression).FirstOrDefaultAsync();
    }

    public virtual void InsertOne(TEntity entity)
    {
        _collection.InsertOne(entity);
    }

    public virtual async Task InsertOneAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public void InsertMany(ICollection<TEntity> entities)
    {
        _collection.InsertMany(entities);
    }

    public virtual async Task InsertManyAsync(ICollection<TEntity> entities)
    {
        await _collection.InsertManyAsync(entities);

    }

    public void ReplaceOne(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
        _collection.FindOneAndReplace(filter, entity);
    }

    public virtual async Task ReplaceOneAsync(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
        await _collection.FindOneAndReplaceAsync(filter, entity);
    }

    public void DeleteById(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, objectId);
        _collection.FindOneAndDelete(filter);
    }

    public virtual async Task DeleteByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TEntity>.Filter.Eq(x => x.Id, objectId);
        await _collection.FindOneAndDeleteAsync(filter);
    }

    public void DeleteMany(Expression<Func<TEntity, bool>> filterExpression)
    {
        _collection.DeleteMany(filterExpression);
    }

    public virtual async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        await _collection.DeleteManyAsync(filterExpression);
    }

    public void DeleteOne(Expression<Func<TEntity, bool>> filterExpression)
    {
        _collection.FindOneAndDelete(filterExpression);
    }

    public virtual async Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        await _collection.FindOneAndDeleteAsync(filterExpression);
    }
}

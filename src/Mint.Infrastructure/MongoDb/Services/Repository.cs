#nullable disable

using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Mint.Infrastructure.MongoDb.Services;

/// <summary>
/// Base Repository gets document
/// </summary>
/// <typeparam name="TDocument"></typeparam>
public class Repository<TDocument> : IRepository<TDocument>
    where TDocument : IDocument
{
    private readonly IMongoCollection<TDocument> _collection;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="settings"></param>
    public Repository(IOptions<MongoDbSettings> settings)
    {
        var database = new MongoClient(settings.Value.ConnectionString).GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }

    private protected string GetCollectionName(Type type)
    {
        return ((BsonCollectionAttribute)type
            .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
            .FirstOrDefault())?.CollectionName;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual IQueryable<TDocument> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    public virtual IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
    {
        return _collection
            .Find(filterExpression)
            .ToEnumerable();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TProjected"></typeparam>
    /// <param name="filterExpression"></param>
    /// <param name="projectedExpression"></param>
    /// <returns></returns>
    public virtual IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression, 
        Expression<Func<TDocument, TProjected>> projectedExpression)
    {
        return _collection
            .Find(filterExpression)
            .Project(projectedExpression)
            .ToEnumerable();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual TDocument FindById(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TDocument>.Filter.Eq(x => x.Id, objectId);
        return _collection.Find(filter).SingleOrDefault();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task<TDocument> FindByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TDocument>.Filter.Eq(x => x.Id, objectId);
        return await _collection.Find(filter).SingleOrDefaultAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).FirstOrDefault();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    public virtual async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return await _collection.Find(filterExpression).FirstOrDefaultAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="document"></param>
    public virtual void InsertOne(TDocument document)
    {
        _collection.InsertOne(document);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="document"></param>
    /// <returns></returns>
    public virtual async Task InsertOneAsync(TDocument document)
    {
        await _collection.InsertOneAsync(document);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collection"></param>
    public void InsertMany(ICollection<TDocument> collection)
    {
        _collection.InsertMany(collection);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public virtual async Task InsertManyAsync(ICollection<TDocument> collection)
    {
        await _collection.InsertManyAsync(collection);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="document"></param>
    public void ReplaceOne(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(x => x.Id, document.Id);
        _collection.FindOneAndReplace(filter, document);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="document"></param>
    /// <returns></returns>
    public virtual async Task ReplaceOneAsync(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(x => x.Id, document.Id);
        await _collection.FindOneAndReplaceAsync(filter, document);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void DeleteById(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TDocument>.Filter.Eq(x => x.Id, objectId);
        _collection.FindOneAndDelete(filter);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task DeleteByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<TDocument>.Filter.Eq(x => x.Id, objectId);
        await _collection.FindOneAndDeleteAsync(filter);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
    {
        _collection.DeleteMany(filterExpression);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    public virtual async Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        await _collection.DeleteManyAsync(filterExpression);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
    {
        _collection.FindOneAndDelete(filterExpression);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    public virtual async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        await _collection.FindOneAndDeleteAsync(filterExpression);
    }
}

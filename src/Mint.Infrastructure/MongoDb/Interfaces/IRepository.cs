using System.Linq.Expressions;

namespace Mint.Infrastructure.MongoDb.Interfaces;

public interface IRepository<TDocument>
    where TDocument : IDocument
{
    /// <summary>
    /// Test
    /// </summary>
    /// <returns>IQueryable<TDocument></returns>
    IQueryable<TDocument> AsQueryable();

    /// <summary>
    /// Gets all data from db
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);

    /// <summary>
    /// Gets filtered data from db
    /// </summary>
    /// <typeparam name="TProjected"></typeparam>
    /// <param name="filterExpression"></param>
    /// <param name="projectedExpression"></param>
    /// <returns></returns>
    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression,
        Expression<Func<TDocument, TProjected>> projectedExpression);

    /// <summary>
    /// Finds first one
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

    /// <summary>
    /// Finds first one async
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    /// <summary>
    /// Finds single one by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TDocument FindById(string id);

    /// <summary>
    /// Finds single one by id async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TDocument> FindByIdAsync(string id);

    /// <summary>
    /// Insert single one
    /// </summary>
    /// <param name="entity"></param>
    void InsertOne(TDocument entity);

    /// <summary>
    /// Insert single one async
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task InsertOneAsync(TDocument entity);

    /// <summary>
    /// Insert collection
    /// </summary>
    /// <param name="entities"></param>
    void InsertMany(ICollection<TDocument> entities);

    /// <summary>
    /// Insert collection async
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task InsertManyAsync(ICollection<TDocument> entities);

    /// <summary>
    /// Update one
    /// </summary>
    /// <param name="entity"></param>
    void ReplaceOne(TDocument entity);

    /// <summary>
    /// Update one async
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task ReplaceOneAsync(TDocument entity);

    /// <summary>
    /// Delete one
    /// </summary>
    /// <param name="filterExpression"></param>
    void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

    /// <summary>
    /// Delete one async
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    /// <summary>
    /// Delete by id
    /// </summary>
    /// <param name="id"></param>
    void DeleteById(string id);

    /// <summary>
    /// Delete by id async
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteByIdAsync(string id);

    /// <summary>
    /// Delete many
    /// </summary>
    /// <param name="filterExpression"></param>
    void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

    /// <summary>
    /// Delete many async
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
}

using MongoDB.Bson;
using MongoDB.Driver;
using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Repositories
{
    public interface IMongoRepository<T, in Key> where T : class, IEntity<Key>, new() where Key : IEquatable<Key>
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Key id);
        Task<T> InsertOneAsync(T entity);
        Task<T> FindOneAndReplaceAsync(Key id, T entity);
        Task<T> FindOneAndReplaceAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> FindOneAndDeleteAsync(T entity);
        Task<T> FindOneAndDeleteAsync(Key id);
        Task<T> FindOneAndDeleteAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindOneAndUpdateAsync(T entity);
        Task<IEnumerable<T>> GetPaginatedAsync(Expression<Func<T, bool>> filter, int page, int pageSize);
        Task<long> CountAsync(Expression<Func<T, bool>> filter);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetSortedAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> sortBy, bool descending = false);
        Task<IEnumerable<T>> GetFilteredAndSortedAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> sortBy, bool descending = false);
        Task<IEnumerable<T>> GetLimitedAsync(Expression<Func<T, bool>> filter, int limit);
        Task<T> UpdateFieldAsync(string id, Expression<Func<T, object>> field, object value);
        Task<BulkWriteResult<T>> BulkWriteAsync(IEnumerable<WriteModel<T>> requests);
        Task<IEnumerable<BsonDocument>> AggregateAsync(PipelineDefinition<T, BsonDocument> pipeline);
        Task<IEnumerable<TResult>> ProjectAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection);
        Task<IEnumerable<TField>> DistinctAsync<TField>(Expression<Func<T, TField>> field, Expression<Func<T, bool>> filter);
        Task<UpdateResult> IncrementFieldAsync(string id, Expression<Func<T, int>> field, int incrementValue);
        Task<T> FindAndModifyAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update);
        Task<IEnumerable<T>> TextSearchAsync(string searchText);
        Task<IEnumerable<T>> GeospatialSearchAsync(Expression<Func<T, bool>> filter, double longitude, double latitude, double maxDistanceInMeters);
    }
}

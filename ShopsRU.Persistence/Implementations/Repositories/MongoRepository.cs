using MongoDB.Bson;
using MongoDB.Driver;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Domain.Common;
using ShopsRU.Infrastructure.Configurations.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Repositories
{

    public class MongoRepository<T> : IMongoRepository<T, string> where T : MongoBaseEntity, new()
    {
        IMongoCollection<T> _collection;
        public MongoRepository(IMongoConfiguration options)
        {
            var client = new MongoClient(options.ConnectionString);
            var db = client.GetDatabase(options.DatabaseName);
            _collection = db.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
       ? _collection.AsQueryable().AsEnumerable().ToList()
       : _collection.AsQueryable().Where(predicate).ToList();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<T> InsertOneAsync(T entity)
        {

            await _collection.InsertOneAsync(entity, new InsertOneOptions { BypassDocumentValidation = false });
            return entity;
        }
        public async Task<T> FindOneAndReplaceAsync(string id, T entity)
        {
            entity.GetType().GetProperty(nameof(entity.UpdatedDate)).SetValue(nameof(entity.UpdatedDate), DateTime.Now);
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }
        public async Task<T> FindOneAndReplaceAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            entity.GetType().GetProperty(nameof(entity.UpdatedDate)).SetValue(nameof(entity.UpdatedDate), DateTime.Now);
            return await _collection.FindOneAndReplaceAsync(predicate, entity);
        }
        public async Task<T> FindOneAndDeleteAsync(T entity)
        {

            return await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);

        }
        public async Task<T> FindOneAndDeleteAsync(string id)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }
        public async Task<T> FindOneAndDeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.FindOneAndDeleteAsync(filter);
        }
        public async Task<T> FindOneAndUpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);

            var update = Builders<T>.Update
           .Set("IsDeleted", true)
           .Set("DeletedDate", DateTime.Now);
            await _collection.UpdateOneAsync(filter, update);
            return entity;
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> filter)
        {
            return _collection.CountDocumentsAsync(filter);
        }

        public async Task<IEnumerable<T>> GetPaginatedAsync(Expression<Func<T, bool>> filter, int page, int pageSize)
        {
            return await _collection.Find(filter).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetSortedAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> sortBy, bool descending = false)
        {
            var sort = descending ? Builders<T>.Sort.Descending(sortBy) : Builders<T>.Sort.Ascending(sortBy);
            return await _collection.Find(filter).Sort(sort).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetFilteredAndSortedAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> sortBy, bool descending = false)
        {
            var sort = descending ? Builders<T>.Sort.Descending(sortBy) : Builders<T>.Sort.Ascending(sortBy);
            return await _collection.Find(filter).Sort(sort).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetLimitedAsync(Expression<Func<T, bool>> filter, int limit)
        {
            return await _collection.Find(filter).Limit(limit).ToListAsync();
        }

        public Task<T> UpdateFieldAsync(string id, Expression<Func<T, object>> field, object value)
        {
            throw new NotImplementedException();
        }

        public async Task<BulkWriteResult<T>> BulkWriteAsync(IEnumerable<WriteModel<T>> requests)
        {
            return await _collection.BulkWriteAsync(requests);
        }

        public async Task<IEnumerable<BsonDocument>> AggregateAsync(PipelineDefinition<T, BsonDocument> pipeline)
        {
            return await _collection.Aggregate(pipeline).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> ProjectAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection)
        {
            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<IEnumerable<TField>> DistinctAsync<TField>(Expression<Func<T, TField>> field, Expression<Func<T, bool>> filter)
        {
            return await _collection.Distinct(field, filter).ToListAsync();
        }

        public async Task<UpdateResult> IncrementFieldAsync(string id, Expression<Func<T, int>> field, int incrementValue)
        {
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            var update = Builders<T>.Update.Inc(field, incrementValue);
            return await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<T> FindAndModifyAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            return await _collection.FindOneAndUpdateAsync(filter, update);
        }

        public async Task<IEnumerable<T>> TextSearchAsync(string searchText)
        {
            var filter = Builders<T>.Filter.Text(searchText);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GeospatialSearchAsync(Expression<Func<T, bool>> filter, double longitude, double latitude, double maxDistanceInMeters)
        {
            var locationFilter = Builders<T>.Filter.NearSphere("Location", longitude, latitude, maxDistanceInMeters);
            var combinedFilter = Builders<T>.Filter.And(filter, locationFilter);
            return await _collection.Find(combinedFilter).ToListAsync();
        }
    }
}

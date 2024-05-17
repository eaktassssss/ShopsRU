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

        public async Task<T> InsertAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
            return entity;
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public async Task<T> DeleteAsync(string id)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}

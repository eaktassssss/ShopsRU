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
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(Key id, T entity);
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(Key id);
        Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}

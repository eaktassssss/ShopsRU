using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Infrastructure.Implementations.Caching.Redis
{
    public interface IRedisCacheService
    {
        void RemoveCache(string key);
        T GetCache<T>(string key);
        void SetCache<T>(string key, T value, DateTimeOffset expirationTime);
        ConnectionMultiplexer Connect();
        IDatabase Database(int db, IConnectionMultiplexer connectionMultiplexer);
    }
}

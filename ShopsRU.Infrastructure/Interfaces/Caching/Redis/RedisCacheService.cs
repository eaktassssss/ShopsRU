using Microsoft.Extensions.Options;
using ShopsRU.Infrastructure.Configurations.Caching.Redis;
using ShopsRU.Infrastructure.Implementations.Caching.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopsRU.Infrastructure.Interfaces.Caching.Redis
{
    public  class RedisCacheService:IRedisCacheService
    {
        private readonly RedisConfiguration _configurationMonitor;
        private readonly IDatabase _database;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public RedisCacheService(IOptionsMonitor<RedisConfiguration> configurationMonitor)
        {
            _configurationMonitor = configurationMonitor.CurrentValue;
            _connectionMultiplexer = Connect();
            _database = Database(db: _configurationMonitor.Database, connectionMultiplexer: _connectionMultiplexer);
        }
        public ConnectionMultiplexer Connect()
        {
            try
            {
                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(_configurationMonitor.RedisConnectionString);
                return connectionMultiplexer;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public IDatabase Database(int db, IConnectionMultiplexer connectionMultiplexer)
        {
            IDatabase database = connectionMultiplexer.GetDatabase(db);
            return database;
        }
        public T GetCache<T>(string key)
        {
            RedisValue cacheData = _database.StringGet(key);
            if (!string.IsNullOrEmpty(cacheData))
                return JsonSerializer.Deserialize<T>(cacheData);
            else
                return default;
        }
        public void RemoveCache(string key)
        {
            bool exist = _database.KeyExists(key);
            if (exist)
                _database.KeyDelete(key);
            else
                return;
        }
        public void SetCache<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);
            _database.StringSet(key, JsonSerializer.Serialize<T>(value), expirtyTime);
        }
    }
}

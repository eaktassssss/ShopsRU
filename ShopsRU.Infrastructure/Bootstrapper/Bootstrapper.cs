using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopsRU.Infrastructure.Configurations.Caching.Redis;
using ShopsRU.Infrastructure.Configurations.Mongo;
using ShopsRU.Infrastructure.Implementations.Caching.Redis;
using ShopsRU.Infrastructure.Interfaces.Caching.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Infrastructure.Bootstrapper
{
    public static  class Bootstrapper
    {
        public static void AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRedisCacheService,RedisCacheService>();
            services.Configure<RedisConfiguration>(action=>
            {
                action.RedisConnectionString = configuration.GetSection("Redis:RedisConnectionString").Value;
                action.Database = Convert.ToInt32(configuration.GetSection("Redis:Database").Value); 
            });
            services.AddScoped<IMongoConfiguration, MongoConfiguration>();

            services.Configure<MongoConfiguration>(action =>
            {
                action.ConnectionString = configuration.GetSection("Mongo:MongoConnectionString").Value;
                action.DatabaseName =configuration.GetSection("Mongo:DatabaseName").Value;
            });
            services.AddSingleton<IMongoConfiguration>(x => x.GetRequiredService<IOptions<MongoConfiguration>>().Value);
        }
    }
}

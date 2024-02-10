using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Infrastructure.Configurations.Caching.Redis
{
    public class RedisConfiguration
    {
        public string RedisConnectionString { get; set; }
        public int Database { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Infrastructure.Configurations.Mongo
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

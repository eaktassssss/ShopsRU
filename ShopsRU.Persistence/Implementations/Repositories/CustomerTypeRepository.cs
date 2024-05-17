using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Configurations.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Repositories
{
    public class CustomerTypeRepository : MongoRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(IMongoConfiguration options) : base(options)
        {
        }
    }
}

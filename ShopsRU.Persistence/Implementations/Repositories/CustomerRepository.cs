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
    public class CustomerRepository : MongoRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMongoConfiguration options) : base(options)
        {
        }
    }
}

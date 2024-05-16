
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Configurations.Mongo;
using ShopsRU.Persistence.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Repositories
{
    public class CategoryRepository : MongoRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoConfiguration options) : base(options)
        {
        }
    }
}

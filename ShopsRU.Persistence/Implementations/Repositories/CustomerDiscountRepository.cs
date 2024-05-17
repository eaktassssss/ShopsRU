﻿


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
    public class CustomerDiscountRepository : MongoRepository<CustomerDiscount>, ICustomerDiscountRepository
    {
        public CustomerDiscountRepository(IMongoConfiguration options) : base(options)
        {
        }
    }
}

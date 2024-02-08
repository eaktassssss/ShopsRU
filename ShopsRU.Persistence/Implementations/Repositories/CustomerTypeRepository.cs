using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Domain.Entities;
using ShopsRU.Persistence.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Repositories
{
    public class CustomerTypeRepository : EfRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(ShopsRUContext ShopsRUContext) : base(ShopsRUContext)
        {
        }
    }
}

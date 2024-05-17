using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Repositories
{
    public  interface IOrderRepository:IMongoRepository<Order,string>
    {
    }
}

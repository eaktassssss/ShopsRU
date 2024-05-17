using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class CustomerType :MongoBaseEntity
    {
        public string Type { get; set; }
    }
}

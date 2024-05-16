using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Product : MongoBaseEntity
    {
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}

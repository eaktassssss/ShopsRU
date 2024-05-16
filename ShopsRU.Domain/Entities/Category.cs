
using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Category : MongoBaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
         
    }
}

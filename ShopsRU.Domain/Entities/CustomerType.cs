using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class CustomerType:BaseEntity
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
            CustomerDiscounts = new HashSet<CustomerDiscount>();
        }
        public string Type { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<CustomerDiscount> CustomerDiscounts { get; set; }
    }
}

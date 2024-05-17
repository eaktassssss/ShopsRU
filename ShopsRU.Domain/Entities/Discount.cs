using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Discount  
    {
        public Discount()
        {
            CustomerDiscounts = new HashSet<CustomerDiscount>();
        }
        public string DiscountType { get; set; }
        public int DiscountRate { get; set; }
        public string Description { get; set; }
        public ICollection<CustomerDiscount> CustomerDiscounts { get; set; }

    }
}

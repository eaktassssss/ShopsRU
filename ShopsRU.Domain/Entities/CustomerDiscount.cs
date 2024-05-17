using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public  class CustomerDiscount:MongoBaseEntity 
    {
        public string CustomerTypeId { get; set; }
        public string DiscountId { get; set; }
        public string RuleJson { get; set; }
        public CustomerType CustomerType { get; set; }
        public Discount Discounts { get; set; }

    }
}

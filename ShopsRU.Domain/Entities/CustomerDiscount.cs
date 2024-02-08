using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public  class CustomerDiscount:BaseEntity
    {
        public int CustomerTypeId { get; set; }
        public int DiscountId { get; set; }
        public string RuleJson { get; set; }
        public CustomerType CustomerType { get; set; }
        public Discount Discounts { get; set; }

    }
}

using ShopsRU.Application.Contract.Request.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public  class DiscountStrategyRules
    {
        public int DiscountId { get; set; }
        public int CustomerTypeId { get; set; }

        public string DiscountType { get; set; }
        public int DiscountRate { get; set; }
        public RuleJson RuleJson { get; set; }
    }

  
}

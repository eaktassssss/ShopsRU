using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.DiscountStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.CustomerDiscount
{
    public  class DiscountResponse
    {
        public string Id { get; set; }
        public string DiscountId { get; set; }
        public string CustomerTypeId { get; set; }
        public RuleJson RuleJson { get; set; }
    }

    
}

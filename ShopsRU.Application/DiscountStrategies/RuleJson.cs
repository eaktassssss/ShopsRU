using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public class RuleJson
    {
        public List<int> ExcludeCategories { get; set; }
        public int CustomerAgeYear { get; set; }
        public int FixedAmount { get; set; }
        public decimal FixedDiscountAmount { get; set; }
        public bool LoyalCustomerPriority { get; set; }
        public decimal LoyalCustomerDiscountRate { get; set; }

    }
}

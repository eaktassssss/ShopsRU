using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Services
{
    public  interface IDiscountService
    {
            Task<Order> ProductBasedApplyDiscountAsync(Customer customer, Order order);
            Task<DiscountStrategyRule> GetDiscountStrategyRulesAsync(int customerTypeId);
            void ApplyThresholdBasedExtraDiscount(decimal netAmount, DiscountStrategyRule discountStrategyRules, out decimal fixedDiscountAmount);
    }
}

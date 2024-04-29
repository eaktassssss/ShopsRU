using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Domain.Entities;
using ShopsRU.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class DiscountService : IDiscountService
    {
        IDiscountStrategy _discountStrategy;
        ICustomerDiscountRepository _customerDiscountRepository;
        public DiscountService(IDiscountStrategy discountStrategy, ICustomerDiscountService customerDiscountService, ICustomerDiscountRepository customerDiscountRepository)
        {
            _discountStrategy = discountStrategy;
            _customerDiscountRepository = customerDiscountRepository;

        }
        public async Task<Order> ProductBasedApplyDiscountAsync(Customer customer, Order order)
        {
            decimal totalFixedDiscountAmount = 0;
            decimal totalDiscountAmount = 0;
            var discountStrategyRules = await GetDiscountStrategyRulesAsync(customer.CustomerTypeId);
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.IsDiscountApplied = false;
                orderItem.LineDiscountAmount = 0;

                if (discountStrategyRules.RuleJson != null)
                {
                    var isApplyDiscount = discountStrategyRules.RuleJson.ExcludeCategories.Any(x => x == orderItem.Product.CategoryId);
                    if (!isApplyDiscount)
                    {
                        var discount = _discountStrategy.ApplyProductDiscountForCustomerType(discountStrategyRules, customer, orderItem.LineAmount);
                        orderItem.IsDiscountApplied = true;
                        orderItem.LineDiscountAmount = discount.DiscountAmount;
                    }
                }
            }
            order.TotalOrderAmount = order.TotalOrderAmount = order.OrderItems.Sum(x => x.LineAmount);
            totalDiscountAmount = order.OrderItems.Sum(x => x.LineDiscountAmount);
            order.NetAmount = order.TotalOrderAmount - totalDiscountAmount;

            if (discountStrategyRules.RuleJson != null && order.TotalOrderAmount >= discountStrategyRules.RuleJson.FixedAmount)
            {
                ApplyThresholdBasedExtraDiscount(order.NetAmount, discountStrategyRules, out totalFixedDiscountAmount);
                order.IsFixedDiscountApplied = true;
                order.TotalFixedDiscountAmount = totalFixedDiscountAmount;
            }
            order.TotalDiscountAmount = totalDiscountAmount + totalFixedDiscountAmount;
            order.NetAmount= order.TotalOrderAmount - order.TotalDiscountAmount;
            return order;
        }
        public void ApplyThresholdBasedExtraDiscount(decimal netAmount, DiscountStrategyRule discountStrategyRule, out decimal fixedDiscountAmount)
        {
            int thresholdDivisor = discountStrategyRule.RuleJson.FixedAmount;
            decimal discountPerThreshold = discountStrategyRule.RuleJson.FixedDiscountAmount;
            int numberOfThresholds = (int)(netAmount / thresholdDivisor);
            fixedDiscountAmount = numberOfThresholds * discountPerThreshold; 
        }
        public async Task<DiscountStrategyRule> GetDiscountStrategyRulesAsync(int customerTypeId)
        {
            var customerDiscount = await _customerDiscountRepository.GetAll().Include(x => x.Discounts).FirstOrDefaultAsync(x => x.CustomerTypeId == customerTypeId);
            if (customerDiscount != null)
            {
                var discountStrategyRequest = new DiscountStrategyRule();
                discountStrategyRequest.CustomerTypeId = customerDiscount.CustomerTypeId;
                discountStrategyRequest.DiscountRate = customerDiscount.Discounts.DiscountRate;
                discountStrategyRequest.DiscountType = customerDiscount.Discounts.DiscountType;
                var ruleJson = JsonConvert.DeserializeObject<RuleJson>(customerDiscount.RuleJson);
                discountStrategyRequest.RuleJson = new RuleJson() { CustomerAgeYear = ruleJson.CustomerAgeYear, ExcludeCategories = ruleJson.ExcludeCategories, FixedAmount = ruleJson.FixedAmount, FixedDiscountAmount = ruleJson.FixedDiscountAmount, LoyalCustomerDiscountRate = ruleJson.LoyalCustomerDiscountRate, LoyalCustomerPriority = ruleJson.LoyalCustomerPriority };
                return discountStrategyRequest;
            }
            else
            {
                return new DiscountStrategyRule();
            }
        }
    }
}

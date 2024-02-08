using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public class DiscountStrategy : IDiscountStrategy
    {
        public ApplyDiscountResponse ApplyDiscount(DiscountStrategyRules discountStrategyRules, Customer customer, decimal totalAmount)
        {
            ApplyDiscountResponse applyDiscountResponse = new ApplyDiscountResponse();
            bool isPercentageDiscountApplied = false;
            if (customer.CustomerTypeId == (int)Domain.Enums.CustomerTypes.Employee && !isPercentageDiscountApplied)
            {
                applyDiscountResponse.DiscountAmount += totalAmount / 100 * discountStrategyRules.DiscountRate;
                isPercentageDiscountApplied = true;
            }
            if (customer.CustomerTypeId == (int)Domain.Enums.CustomerTypes.Member && !isPercentageDiscountApplied)
            {
                if (IsCustomerLoyal(customer.JoiningDate, discountStrategyRules.RuleJson.CustomerAgeYear) && discountStrategyRules.RuleJson.LoyalCustomerPriority)
                {
                    applyDiscountResponse.DiscountAmount += totalAmount / 100 * discountStrategyRules.RuleJson.LoyalCustomerDiscountRate;
                    isPercentageDiscountApplied = true;
                }
                else
                {
                    applyDiscountResponse.DiscountAmount += totalAmount / 100 * discountStrategyRules.DiscountRate;
                    isPercentageDiscountApplied = true;
                }
            }
            int discountForEachHundredDollar = (int)totalAmount / discountStrategyRules.RuleJson.FixedAmount;
            applyDiscountResponse.DiscountAmount += discountForEachHundredDollar * discountStrategyRules.RuleJson.FixedDiscountAmount;
            applyDiscountResponse.NetAmount = totalAmount - applyDiscountResponse.DiscountAmount;
            return applyDiscountResponse;
        }
        private bool IsCustomerLoyal(DateTime joiningDate, int customerAgeYear)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan customerAge = currentDate - joiningDate;
            return customerAge.TotalDays >= 365 * customerAgeYear;
        }
    }
}

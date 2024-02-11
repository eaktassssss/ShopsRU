using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public class DiscountStrategy : IDiscountStrategy
    {
        //  If the user is an employee of the store, he gets a 30% discount
        // If the user is an affiliate of the store, he gets a 10% discount
        // If the user has been a customer for over 2 years, he gets a 5% discount.
        // For every $100 on the bill, there would be a $ 5 discount(e.g. for $ 990, you get $ 45 as a discount).
        //The percentage based discounts do not apply on groceries.
        //A user can get only one of the percentage based discounts on a bill.
        public ApplyDiscountResponse ApplyProductDiscountForCustomerType(DiscountStrategyRule discountStrategyRules, Customer customer, decimal totalAmount)
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
            applyDiscountResponse.NetAmount = totalAmount - applyDiscountResponse.DiscountAmount;
            applyDiscountResponse.TotalAmount = totalAmount;
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

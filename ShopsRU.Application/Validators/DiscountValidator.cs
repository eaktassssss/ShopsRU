using FluentValidation;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{
    public class DiscountValidator : AbstractValidator<CreateDiscountRequest>
    {
        public DiscountValidator()
        {
            RuleFor(discountCustomer => discountCustomer.DiscountId)
                .GreaterThan(0).WithMessage("DiscountId must be a positive number.");

            RuleFor(discountCustomer => discountCustomer.CustomerTypeId)
                .GreaterThan(0).WithMessage("CustomerTypeId must be a positive number.");
        }
    }
}

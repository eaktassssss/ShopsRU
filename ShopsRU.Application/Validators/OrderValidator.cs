using FluentValidation;
using ShopsRU.Application.Contract.Request.Order;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{
    public class OrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public OrderValidator()
        {
            //RuleFor(order => order.CustomerId)
            //    .GreaterThan(0).WithMessage("CustomerId must be a positive number.");

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("OrderDate cannot be empty.");



            RuleFor(order => order.UserId)
                .GreaterThan(0).WithMessage("UserId must be a positive number.");
        }
    }
}

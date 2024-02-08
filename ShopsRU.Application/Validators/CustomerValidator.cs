using FluentValidation;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{

    public class CustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.")
                .Length(2, 50).WithMessage("FirstName must be between 2 and 50 characters in length.");

            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .Length(2, 50).WithMessage("LastName must be between 2 and 50 characters in length.");

            RuleFor(customer => customer.JoiningDate)
                .NotEmpty().WithMessage("JoiningDate cannot be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("JoiningDate cannot be a future date.");

            RuleFor(customer => customer.CustomerTypeId)
                .GreaterThan(0).WithMessage("CustomerTypeId must be a positive number.");
        }
    }
}

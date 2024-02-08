using FluentValidation;
using ShopsRU.Application.Contract.Request.Invoice;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{
 

    public class InvoiceValidator : AbstractValidator<CreateInvoiceRequest>
    {
        public InvoiceValidator()
        {
            RuleFor(invoice => invoice.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be a positive number.");

            RuleFor(invoice => invoice.InvoiceDate)
                .NotEmpty().WithMessage("InvoiceDate cannot be empty.");
                
            RuleFor(invoice => invoice.BillingUserId)
                .GreaterThan(0).WithMessage("BillingUserId must be a positive number.");
        }
    }
}

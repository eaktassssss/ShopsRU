using FluentValidation;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Product Name is required.");
            RuleFor(product => product.Price).NotEmpty().WithMessage("Product Price is required.")
                .GreaterThan(0).WithMessage("Product Price must be greater than zero.");
            //RuleFor(product => product.CategoryId).NotEmpty().WithMessage("Product CategoryId is required.")
            //    .GreaterThan(0).WithMessage("Product CategoryId must be greater than zero.");
        }
    }
}

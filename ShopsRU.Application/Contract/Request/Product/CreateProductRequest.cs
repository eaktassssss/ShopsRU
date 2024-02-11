using ShopsRU.Application.Contract.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CreateProductResponse MapToResponse(Domain.Entities.Product product)
        {
            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CreatedOn = product.CreatedOn,
                
                
            };
        }

        public Domain.Entities.Product MapToEntity()
        {
            return new Domain.Entities.Product()
            {
                Name = Name,
                Price = Price,
                CategoryId = CategoryId,
            };

        }
    }
}

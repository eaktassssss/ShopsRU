using ShopsRU.Application.Contract.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Product
{
    public class UpdateProductRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public UpdateProductResponse MapToResponse(Domain.Entities.Product product)
        {
            return new UpdateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                UpdatedDate = product.UpdatedDate,
            };
        }
        public Domain.Entities.Product MapToEntity()
        {
            return new Domain.Entities.Product()
            {
                Id=this.Id,
                Name = Name,
                Price = Price,
                CategoryId = CategoryId,
            };

        }
    }
}

using ShopsRU.Application.Contract.Common;
using ShopsRU.Application.Contract.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Product
{
    public class SearchProductRequest: SearchRequest
    {
        public List<SearchProductResponse> MapToResponse(IEnumerable<Domain.Entities.Product> products)
        {
            List<SearchProductResponse> searchProductResponse = new List<SearchProductResponse>();
            foreach (var product in products)
            {
                var response = new SearchProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CreatedDate = product.CreatedDate,
                };
                searchProductResponse.Add(response);
            }
            return searchProductResponse.ToList();
        }
    }
}

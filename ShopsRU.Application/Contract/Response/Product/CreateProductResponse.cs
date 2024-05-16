using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.Product
{
    public class CreateProductResponse
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

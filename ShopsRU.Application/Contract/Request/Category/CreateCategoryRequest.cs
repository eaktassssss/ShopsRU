using ShopsRU.Application.Contract.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Category
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public CreateCategoryResponse MapToResponse(ShopsRU.Domain.Entities.Category category)
        {
            return new CreateCategoryResponse { Id = category.Id, Name = category.Name, CreatedOn = category.CreatedOn };
        }
        public ShopsRU.Domain.Entities.Category MapToEntity()
        {
            return new Domain.Entities.Category()
            {
                Name = this.Name,
            };
        }
    }
}

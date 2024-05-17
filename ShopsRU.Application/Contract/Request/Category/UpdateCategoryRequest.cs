using ShopsRU.Application.Contract.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Category
{
    public  class UpdateCategoryRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public UpdateCategoryResponse MapToResponse(ShopsRU.Domain.Entities.Category category)
        {
            return new UpdateCategoryResponse { Id = category.Id, Name = category.Name, CreatedDate = category.CreatedDate };
        }
        public ShopsRU.Domain.Entities.Category MapToEntity()
        {
            return new Domain.Entities.Category()
            {
                Name = this.Name,
                Id = this.Id
            };
        }
    }
}

using ShopsRU.Application.Contract.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.Order
{
    public  class CreateOrderResponse
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public CreateOrderResponse MapToResponse(ShopsRU.Domain.Entities.Order  order)
        {
            return  new CreateOrderResponse { OrderDate = order.OrderDate, OrderId = order.Id };
        }

    }
}

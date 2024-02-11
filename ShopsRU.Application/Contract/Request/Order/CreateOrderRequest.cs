using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Order;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Order
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public List<OrderItemRequest> OrderItemRequest { get; set; }
        public CreateOrderResponse MapToResponse(ShopsRU.Domain.Entities.Order order)
        {
            return new CreateOrderResponse { OrderDate = order.OrderDate, OrderId = order.Id };
        }


        public ShopsRU.Domain.Entities.Order MapToEntity()
        {
            return new Domain.Entities.Order()
            {
                CustomerId = this.CustomerId,
                OrderDate = DateTime.Now,
                UserId = this.UserId

            };
        }
    }
}

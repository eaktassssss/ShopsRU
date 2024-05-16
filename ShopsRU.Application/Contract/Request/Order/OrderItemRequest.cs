using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Order
{
    public  class OrderItemRequest
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

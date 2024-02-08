using ShopsRU.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int UserId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}

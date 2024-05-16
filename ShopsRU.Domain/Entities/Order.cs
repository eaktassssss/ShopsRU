﻿using ShopsRU.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalFixedDiscountAmount { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public bool IsFixedDiscountApplied { get; set; } = false;

        public int UserId { get; set; }
    }
}

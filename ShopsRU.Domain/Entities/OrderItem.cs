﻿using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class OrderItem  :MongoBaseEntity
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal LineAmount { get; set; }
        public bool IsDiscountApplied { get; set; }
        public decimal LineDiscountAmount { get; set; }
    }
}

﻿using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}

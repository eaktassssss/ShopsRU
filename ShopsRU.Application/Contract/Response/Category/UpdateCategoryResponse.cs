﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.Category
{
    public  class UpdateCategoryResponse
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
    }
}

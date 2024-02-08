﻿using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Services
{
    public  interface ICategoryService
    {
        Task<ServiceDataResponse<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest);

        Task<ServiceDataResponse<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
    }
}

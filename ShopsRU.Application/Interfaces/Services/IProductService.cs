using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<ServiceDataResponse<CreateProductResponse>> CreateAsync(CreateProductRequest createProductRequest);
        Task<ServiceDataResponse<UpdateProductResponse>> UpdateAsync(UpdateProductRequest  updateProductRequest);

        Task<ServiceDataResponse<UpdateProductResponse>> DeleteAsync(string id);
    }
}

using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Services
{
    public  interface ICustomerService
    {
        Task<ServiceDataResponse<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest  createCustomerRequest);
        Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(string id);
        Task<ServiceDataResponse<List<GetAllCustomerResponse>>> GetAllAsync();

        Task<ServiceDataResponse<UpdateCustomerResponse>> UpdateAsync(UpdateCustomerRequest  updateCustomerRequest);

        Task<ServiceDataResponse<UpdateCustomerResponse>> DeleteAsync(string id);
    }
}

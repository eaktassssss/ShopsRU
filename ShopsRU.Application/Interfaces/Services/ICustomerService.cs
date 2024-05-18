using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Wrappers;

namespace ShopsRU.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ServiceResponse> CreateAsync(CreateCustomerRequest createCustomerRequest);
        Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(string id);


        Task<ServiceResponse> UpdateAsync(UpdateCustomerRequest updateCustomerRequest);

        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceDataResponse<List<SearchCustomerResponse>>> SearchAsync(SearchCustomerRequest searchCustomerRequest);
    }
}

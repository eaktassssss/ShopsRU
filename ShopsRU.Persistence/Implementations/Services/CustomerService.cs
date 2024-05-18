using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;
using ShopsRU.Infrastructure.Interfaces.Caching.Redis;
using ShopsRU.Infrastructure.Statics;
using ShopsRU.Persistence.Extensions;
using ShopsRU.Persistence.Implementations.Repositories;
using System.Linq.Expressions;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerService : ICustomerService
    {


        ICustomerRepository _customerRepository;

        IResourceService _resourceService;
        public CustomerService(ICustomerRepository customerRepository, IResourceService resourceService)
        {
            _customerRepository = customerRepository;
            _resourceService = resourceService;

        }
        public async Task<ServiceResponse> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {
            var customer = createCustomerRequest.MapToEntity();
            await _customerRepository.InsertOneAsync(customer);

            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(string id)
        {

            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return ServiceDataResponse<GetSingleCustomerResponse>.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);
            }
            GetSingleCustomerResponse getSingleCustomerResponse = new GetSingleCustomerResponse();
            var customerResponse = new GetSingleCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CustomerTypeId = customer.CustomerTypeId, CreatedDate = customer.CreatedDate };
            return ServiceDataResponse<GetSingleCustomerResponse>.CreateServiceResponse(_resourceService, getSingleCustomerResponse.MapToResponse(customer), ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
        }
        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);


            await _customerRepository.FindOneAndReplaceAsync(customer.Id, customer);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }
        public async Task<ServiceResponse> UpdateAsync(UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = await _customerRepository.GetByIdAsync(updateCustomerRequest.Id);
            if (customer == null)
                return ServiceResponse.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);

            var updateEntity = updateCustomerRequest.MapToEntity();
            await _customerRepository.FindOneAndReplaceAsync(customer.Id, updateEntity);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS); ;
        }

        public async Task<ServiceDataResponse<List<SearchCustomerResponse>>> SearchAsync(SearchCustomerRequest searchCustomerRequest)
        {
            Expression<Func<Customer, bool>> filter;
            filter = x => !x.IsDeleted;
            if (!string.IsNullOrEmpty(searchCustomerRequest.SearchText))
                filter = filter.AndAlso(x => x.FirstName.ToLower().Contains(searchCustomerRequest.SearchText.ToLower()));


            var paginatedData = await _customerRepository.GetPaginatedAsync(filter, searchCustomerRequest.Page, searchCustomerRequest.PageSize);
            var activeCustomersResponse = searchCustomerRequest.MapToResponse(paginatedData);

            return ServiceDataResponse<List<SearchCustomerResponse>>.CreateServiceResponse(_resourceService, activeCustomersResponse, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
        }
    }
}
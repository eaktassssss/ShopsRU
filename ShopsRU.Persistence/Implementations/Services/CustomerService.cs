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
using ShopsRU.Persistence.Implementations.Repositories;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerService : ICustomerService
    {


        ICustomerRepository _customerRepository;

        IResourceService _resourceService;
        IRedisCacheService _redisCacheService;

        public CustomerService(ICustomerRepository customerRepository, IResourceService resourceService, IRedisCacheService redisCacheService)
        {
            _customerRepository = customerRepository;
            _resourceService = resourceService;
            _redisCacheService = redisCacheService;
        }
        public async Task<ServiceDataResponse<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {
            var customer = createCustomerRequest.MapToEntity();
            await _customerRepository.InsertAsync(customer);
            _redisCacheService.RemoveCache(RedisKeys.CustomerCacheKey);
            return ServiceDataResponse<CreateCustomerResponse>.CreateServiceResponse(_resourceService, createCustomerRequest.MapToResponse(customer), ResponseMessages.OPERATION_SUCCESS);
        }

     

        public async Task<ServiceDataResponse<List<GetAllCustomerResponse>>> GetAllAsync()
        {
            var customersCacheData = _redisCacheService.GetCache<List<GetAllCustomerResponse>>(RedisKeys.CustomerCacheKey);
            if (customersCacheData == null)
            {
                var customers = await _customerRepository.GetAll();
                var customerData = customers.Where(x => x.IsDeleted == false).Select(c => new GetAllCustomerResponse()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                }).ToList();
                if (customers.Any())
                {
                    var cacheTime = DateTimeOffset.Now.DateTime.AddMinutes(30);
                    _redisCacheService.SetCache<List<GetAllCustomerResponse>>(RedisKeys.CustomerCacheKey, customerData, cacheTime);
                    return ServiceDataResponse<List<GetAllCustomerResponse>>.CreateServiceResponse(_resourceService, customerData, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
                }
                else
                {
                    return ServiceDataResponse<List<GetAllCustomerResponse>>.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);
                }
            }
            else
            {
                return ServiceDataResponse<List<GetAllCustomerResponse>>.CreateServiceResponse(_resourceService, customersCacheData, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
            }
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

     

        public async Task<ServiceDataResponse<UpdateCustomerResponse>> DeleteAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return ServiceDataResponse<UpdateCustomerResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);


            customer.IsDeleted = true;
            await _customerRepository.UpdateAsync(customer.Id, customer);
            return ServiceDataResponse<UpdateCustomerResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<UpdateCustomerResponse>> UpdateAsync(UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = await _customerRepository.GetByIdAsync(updateCustomerRequest.Id);
            if (customer == null)
                return ServiceDataResponse<UpdateCustomerResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);

            var updateEntity = updateCustomerRequest.MapToEntity();
            await _customerRepository.UpdateAsync(customer.Id, updateEntity);
            return ServiceDataResponse<UpdateCustomerResponse>.CreateServiceResponse(_resourceService, updateCustomerRequest.MapToResponse(updateEntity), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

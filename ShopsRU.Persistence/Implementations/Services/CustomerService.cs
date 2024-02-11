using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;
using ShopsRU.Infrastructure.Implementations.Caching.Redis;
using ShopsRU.Infrastructure.Statics;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerService : ICustomerService
    {


        ICustomerRepository _customerRepository;
        IUnitOfWork _unitOfWork;
        IResourceService _resourceService;
        IRedisCacheService _redisCacheService;
        
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IResourceService resourceService, IRedisCacheService redisCacheService)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;
            _redisCacheService = redisCacheService;
        }
        public async Task<ServiceDataResponse<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {
            var customer = createCustomerRequest.MapToEntity();
            await _customerRepository.AddAsync(customer);
            var result = await _unitOfWork.CommitAsync();
            _redisCacheService.RemoveCache(RedisCacheKeys.CustomerCacheKey);
            return ServiceDataResponse<CreateCustomerResponse>.CreateServiceResponse(_resourceService,createCustomerRequest.MapToResponse(customer),ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<List<GetAllCustomerResponse>>> GetAllAsync()
        {
            var customersCacheData = _redisCacheService.GetCache<List<GetAllCustomerResponse>>(RedisCacheKeys.CustomerCacheKey);
            if (customersCacheData == null)
            {
                var customers = _customerRepository.GetAll().Where(x => x.IsDeleted == false).Select(c => new GetAllCustomerResponse()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                }).ToList();
                if (customers.Any())
                {
                    var cacheTime = DateTimeOffset.Now.DateTime.AddMinutes(30);
                    _redisCacheService.SetCache<List<GetAllCustomerResponse>>(RedisCacheKeys.CustomerCacheKey, customers, cacheTime);
                    return ServiceDataResponse<List<GetAllCustomerResponse>>.CreateServiceResponse(_resourceService, customers, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
                }
                else
                {
                    return ServiceDataResponse<List<GetAllCustomerResponse>>.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);
                }
            }
            else
            {
                return ServiceDataResponse<List<GetAllCustomerResponse>>.CreateServiceResponse(_resourceService,customersCacheData, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
            }
        }

        public async Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(int id)
        {

            var customer = await _customerRepository.GetSingleAsync(x => x.Id == id);
            if (customer == null)
            {
                return ServiceDataResponse<GetSingleCustomerResponse>.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);
            }
            GetSingleCustomerResponse getSingleCustomerResponse = new GetSingleCustomerResponse();
            var customerResponse = new GetSingleCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CustomerTypeId = customer.CustomerTypeId, CreatedOn = customer.CreatedOn };
            return ServiceDataResponse<GetSingleCustomerResponse>.CreateServiceResponse(_resourceService, getSingleCustomerResponse.MapToResponse(customer), ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
        }
    }
}

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
            ServiceDataResponse<CreateCustomerResponse> serviceDataResponse = new ServiceDataResponse<CreateCustomerResponse>();
            var customer = createCustomerRequest.MapToEntity();
            await _customerRepository.AddAsync(customer);
            var result = await _unitOfWork.CommitAsync();
            _redisCacheService.RemoveCache("customers");
            return serviceDataResponse.CreateServiceResponse<CreateCustomerResponse>(result, createCustomerRequest.MapToPaylod(customer), _resourceService);
        }

        public async Task<ServiceDataResponse<List<GetAllCustomerResponse>>> GetAllAsync()
        {
            ServiceDataResponse<List<GetAllCustomerResponse>> serviceDataResponse = new ServiceDataResponse<List<GetAllCustomerResponse>>();

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
                    serviceDataResponse.CreateServiceResponse<List<GetAllCustomerResponse>>(200, customers, _resourceService, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
                    var cacheTime = DateTimeOffset.Now.DateTime.AddMinutes(30);
                    _redisCacheService.SetCache<List<GetAllCustomerResponse>>(RedisCacheKeys.CustomerCacheKey, customers, cacheTime);
                    return serviceDataResponse;
                }
                else
                {
                    serviceDataResponse.CreateServiceResponse<List<GetAllCustomerResponse>>(404, _resourceService, ResponseMessages.DATA_NOT_FOUND);
                }
            }
            else
            {
                serviceDataResponse.CreateServiceResponse<List<GetAllCustomerResponse>>(200, customersCacheData, _resourceService, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
            }
            return serviceDataResponse;

        }

        public async Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(int id)
        {
            ServiceDataResponse<GetSingleCustomerResponse> serviceDataResponse = new ServiceDataResponse<GetSingleCustomerResponse>();

            var customer = await _customerRepository.GetSingleAsync(x => x.Id == id);
            if (customer == null)
            {
                return serviceDataResponse.CreateServiceResponse<GetSingleCustomerResponse>(404, _resourceService, Domain.Enums.ResponseMessages.RESOURCE_NOT_FOUND);

            }
            GetSingleCustomerResponse getSingleCustomerResponse = new GetSingleCustomerResponse();
            serviceDataResponse.Message = _resourceService.GetResource("DATA_RETRIEVED_SUCCESSFULLY");
            serviceDataResponse.StatusCode = 200;
            serviceDataResponse.Success = true;
            serviceDataResponse.Paylod = new GetSingleCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CustomerTypeId = customer.CustomerTypeId, CreatedOn = customer.CreatedOn };
            return serviceDataResponse;
        }
    }
}

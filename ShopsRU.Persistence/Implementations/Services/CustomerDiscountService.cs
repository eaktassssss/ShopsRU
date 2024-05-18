using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerDiscountService : ICustomerDiscountService
    {
        ICustomerDiscountRepository _customerDiscountRepository;
        ICustomerTypeRepository _customerTypeRepository;
        IResourceService _resourceService;
        public CustomerDiscountService(ICustomerDiscountRepository customerDiscountRepository, ICustomerTypeRepository customerTypeRepository, IResourceService resourceService)
        {
            _customerDiscountRepository = customerDiscountRepository;
            _customerTypeRepository = customerTypeRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceResponse> CreateAsync(CreateDiscountRequest createCustomerDiscountRequest)
        {

            var customerType = await _customerTypeRepository.GetByIdAsync(createCustomerDiscountRequest.CustomerTypeId);
            if (customerType == null)
            {
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);
            }
            var customerDiscountExists = await _customerDiscountRepository.GetAsync(x => x.CustomerTypeId == createCustomerDiscountRequest.CustomerTypeId && x.IsDeleted == false);
            if (customerDiscountExists != null)
            {
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.ALREADY_EXISTS);
            }

            var customerDiscount = createCustomerDiscountRequest.MapToEntity();
            await _customerDiscountRepository.InsertOneAsync(customerDiscount);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

﻿using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CustomerDiscountService : ICustomerDiscountService
    {
        ICustomerDiscountRepository _customerDiscountRepository;
        ICustomerTypeRepository _customerTypeRepository;
        IUnitOfWork _unitOfWork;
        IResourceService _resourceService;
        public CustomerDiscountService(ICustomerDiscountRepository customerDiscountRepository, IUnitOfWork unitOfWork, ICustomerTypeRepository customerTypeRepository, IResourceService resourceService)
        {
            _customerDiscountRepository = customerDiscountRepository;
            _unitOfWork = unitOfWork;
            _customerTypeRepository = customerTypeRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<DiscountResponse>> CreateAsync(CreateDiscountRequest createCustomerDiscountRequest)
        {

            var customerType = await _customerTypeRepository.GetByIdAsync(createCustomerDiscountRequest.CustomerTypeId);
            if (customerType == null)
            {
                return ServiceDataResponse<DiscountResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);
            }
            var customerDiscountExists = await _customerDiscountRepository.GetSingleAsync(x => x.CustomerTypeId == createCustomerDiscountRequest.CustomerTypeId && x.IsDeleted == false);
            if (customerDiscountExists != null)
            {
                return ServiceDataResponse<DiscountResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.ALREADY_EXISTS);
            }

            var customerDiscount = createCustomerDiscountRequest.MapToEntity();
            await _customerDiscountRepository.AddAsync(customerDiscount);
            await _unitOfWork.CommitAsync();
            return ServiceDataResponse<DiscountResponse>.CreateServiceResponse(_resourceService, createCustomerDiscountRequest.MapToResponse(customerDiscount), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

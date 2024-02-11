using FluentValidation;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Validators;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
namespace ShopsRU.Persistence.Implementations.Services
{
    public class ProductService : IProductService
    {

        readonly IProductRepository _productRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly IResourceService _resourceService;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IResourceService resourceService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateProductResponse>> CreateAsync(CreateProductRequest createProductRequest)
        {
            var productExists = await _productRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createProductRequest.Name.Trim().ToLower());
            if (productExists != null)
            {
                return ServiceDataResponse<CreateProductResponse>.CreateServiceResponse(_resourceService, createProductRequest.MapToResponse(productExists), Domain.Enums.ResponseMessages.ALREADY_EXISTS);
            }
            var product = createProductRequest.MapToEntity();
            await _productRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return ServiceDataResponse<CreateProductResponse>.CreateServiceResponse(_resourceService, createProductRequest.MapToResponse(product), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

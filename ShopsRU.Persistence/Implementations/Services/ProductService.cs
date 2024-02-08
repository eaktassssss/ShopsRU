using FluentValidation;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Invoice;
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
            ServiceDataResponse<CreateProductResponse> serviceDataResponse = new ServiceDataResponse<CreateProductResponse>();

            var productCheck = await _productRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createProductRequest.Name.Trim().ToLower());
            if (productCheck != null)
            {
                return serviceDataResponse.CreateServiceResponse<CreateProductResponse>(409, _resourceService, Domain.Enums.ResponseMessages.ALREADY_EXISTS);
            }
            var product = createProductRequest.MapToEntity();
            await _productRepository.AddAsync(product);
            var result = await _unitOfWork.CommitAsync();
            return serviceDataResponse.CreateServiceResponse<CreateProductResponse>(result, createProductRequest.MapToPaylod(product), _resourceService);
        }
    }
}

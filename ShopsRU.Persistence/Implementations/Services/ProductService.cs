using FluentValidation;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Validators;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
namespace ShopsRU.Persistence.Implementations.Services
{
    public class ProductService : IProductService
    {

        readonly IProductRepository _productRepository;
        readonly IResourceService _resourceService;

        public ProductService(IProductRepository productRepository, IResourceService resourceService)
        {
            _productRepository = productRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateProductResponse>> CreateAsync(CreateProductRequest createProductRequest)
        {
            var productExists = await _productRepository.GetAsync(x => x.Name.Trim().ToLower() == createProductRequest.Name.Trim().ToLower());
            if (productExists != null)
            {
                return ServiceDataResponse<CreateProductResponse>.CreateServiceResponse(_resourceService, createProductRequest.MapToResponse(productExists), Domain.Enums.ResponseMessages.ALREADY_EXISTS);
            }
            var product = createProductRequest.MapToEntity();
            await _productRepository.InsertAsync(product);
            return ServiceDataResponse<CreateProductResponse>.CreateServiceResponse(_resourceService, createProductRequest.MapToResponse(product), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<UpdateProductResponse>> DeleteAsync(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ServiceDataResponse<UpdateProductResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);


            product.IsDeleted = true;
            await _productRepository.UpdateAsync(product.Id, product);
            return ServiceDataResponse<UpdateProductResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<UpdateProductResponse>> UpdateAsync(UpdateProductRequest updateProductRequest)
        {
            var product = await _productRepository.GetByIdAsync(updateProductRequest.Id);
            if (product == null)
                return ServiceDataResponse<UpdateProductResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);

            var updateEntity = updateProductRequest.MapToEntity();
            await _productRepository.UpdateAsync(product.Id, updateEntity);
            return ServiceDataResponse<UpdateProductResponse>.CreateServiceResponse(_resourceService, updateProductRequest.MapToResponse(product), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

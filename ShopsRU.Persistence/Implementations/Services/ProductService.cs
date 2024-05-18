using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;
using ShopsRU.Persistence.Extensions;
using System.Linq.Expressions;
using System.Linq;

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
        public async Task<ServiceResponse> CreateAsync(CreateProductRequest createProductRequest)
        {
            var productExists = await _productRepository.GetAsync(x => x.Name.Trim().ToLower() == createProductRequest.Name.Trim().ToLower());
            if (productExists != null)
            {
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.ALREADY_EXISTS);
            }
            var product = createProductRequest.MapToEntity();
            await _productRepository.InsertOneAsync(product);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }
        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);


            await _productRepository.FindOneAndUpdateAsync(product);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<List<SearchProductResponse>>> SearchAsync(SearchProductRequest searchProductRequest)
        {
            Expression<Func<Product, bool>> filter;
            filter = x => !x.IsDeleted;
            if (!string.IsNullOrEmpty(searchProductRequest.SearchText))
                filter = filter.AndAlso(x => x.Name.ToLower().Contains(searchProductRequest.SearchText.ToLower()));


            var paginatedData = await _productRepository.GetPaginatedAsync(filter, searchProductRequest.Page, searchProductRequest.PageSize);
            var activeProductsResponse = searchProductRequest.MapToResponse(paginatedData);
            return ServiceDataResponse<List<SearchProductResponse>>.CreateServiceResponse(_resourceService, activeProductsResponse, ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProductRequest updateProductRequest)
        {
            var product = await _productRepository.GetByIdAsync(updateProductRequest.Id);
            if (product == null)
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);

            var updateEntity = updateProductRequest.MapToEntity();
            await _productRepository.FindOneAndReplaceAsync(product.Id, updateEntity);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

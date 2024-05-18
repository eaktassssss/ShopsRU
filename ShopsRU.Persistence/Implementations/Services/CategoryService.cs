using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Domain.Enums;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        IResourceService _resourceService;
        public CategoryService(ICategoryRepository categoryRepository, IResourceService resourceService)
        {
            _categoryRepository = categoryRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceResponse> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            var categoryExists = await _categoryRepository.GetAsync(x => x.Name == createCategoryRequest.Name);
            if (categoryExists != null)
            {
                return ServiceResponse.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.ALREADY_EXISTS);
            }
            var category = createCategoryRequest.MapToEntity();
            await _categoryRepository.InsertOneAsync(category);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {

            var category = await _categoryRepository.GetByIdAsync(updateCategoryRequest.Id);
            if (category == null)
            {
                return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.DATA_NOT_FOUND);
            }
            category.Name = updateCategoryRequest.Name;
            await _categoryRepository.FindOneAndReplaceAsync(category.Id, category);
            return ServiceResponse.CreateServiceResponse(_resourceService, ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

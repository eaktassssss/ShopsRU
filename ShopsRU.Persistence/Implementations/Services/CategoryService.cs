using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Product;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;


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


        public async Task<ServiceDataResponse<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {

            var categoryExists = await _categoryRepository.GetByIdAsync(createCategoryRequest.Name);
            if (categoryExists != null)
            {
                return ServiceDataResponse<CreateCategoryResponse>.CreateServiceResponse(_resourceService, createCategoryRequest.MapToResponse(categoryExists), Domain.Enums.ResponseMessages.ALREADY_EXISTS);
            }

            var category = createCategoryRequest.MapToEntity();
            await _categoryRepository.InsertAsync(category);
            return ServiceDataResponse<CreateCategoryResponse>.CreateServiceResponse(_resourceService, createCategoryRequest.MapToResponse(category), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {

            var category = await _categoryRepository.GetByIdAsync(updateCategoryRequest.Id);
            if (category == null)
            {
                return ServiceDataResponse<UpdateCategoryResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);
            }

            category.Name = updateCategoryRequest.Name;
            await _categoryRepository.UpdateAsync(category.Id, category);
            return ServiceDataResponse<UpdateCategoryResponse>.CreateServiceResponse(_resourceService, updateCategoryRequest.MapToResponse(category), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

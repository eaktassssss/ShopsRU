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
        readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IResourceService resourceService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;

        }


        public async Task<ServiceDataResponse<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {

            var categoryExists = await _categoryRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createCategoryRequest.Name.Trim().ToLower());
            if (categoryExists != null)
            {
                return ServiceDataResponse<CreateCategoryResponse>.CreateServiceResponse(_resourceService, createCategoryRequest.MapToResponse(categoryExists), Domain.Enums.ResponseMessages.ALREADY_EXISTS);


            }

            var category = createCategoryRequest.MapToEntity();
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();
            return ServiceDataResponse<CreateCategoryResponse>.CreateServiceResponse(_resourceService, createCategoryRequest.MapToResponse(category), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }

        public async Task<ServiceDataResponse<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {

            var category = await _categoryRepository.GetByIdAsync(updateCategoryRequest.Id);
            if (category == null)
            {

                return ServiceDataResponse<UpdateCategoryResponse>.CreateServiceResponse(_resourceService,Domain.Enums.ResponseMessages.DATA_NOT_FOUND);
            }

            category.Id = updateCategoryRequest.Id;
            category.Name = updateCategoryRequest.Name;
            await _categoryRepository.UpdateAsync(category);
           await _unitOfWork.CommitAsync();
            return ServiceDataResponse<UpdateCategoryResponse>.CreateServiceResponse(_resourceService, updateCategoryRequest.MapToResponse(category), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

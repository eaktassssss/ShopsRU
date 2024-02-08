using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
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
            ServiceDataResponse<CreateCategoryResponse> serviceDataResponse = new ServiceDataResponse<CreateCategoryResponse>();

            var categoryCheck = await _categoryRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createCategoryRequest.Name.Trim().ToLower());
            if (categoryCheck != null)
            {
                return serviceDataResponse.CreateServiceResponse<CreateCategoryResponse>(409, _resourceService, Domain.Enums.ResponseMessages.ALREADY_EXISTS);

            }

            var category = createCategoryRequest.MapToEntity();
            await _categoryRepository.AddAsync(category);
            var result = await _unitOfWork.CommitAsync();
            return serviceDataResponse.CreateServiceResponse<CreateCategoryResponse>(result, createCategoryRequest.MapToPaylod(category), _resourceService);
        }

        public async Task<ServiceDataResponse<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            ServiceDataResponse<UpdateCategoryResponse> serviceDataResponse = new ServiceDataResponse<UpdateCategoryResponse>();

            var category = await _categoryRepository.GetByIdAsync(updateCategoryRequest.Id);
            if (category == null)
            {
                return serviceDataResponse.CreateServiceResponse<UpdateCategoryResponse>(409, _resourceService, Domain.Enums.ResponseMessages.RESOURCE_NOT_FOUND);
            }

            category.Id = updateCategoryRequest.Id;
            category.Name = updateCategoryRequest.Name;
            await _categoryRepository.UpdateAsync(category);
            var result = await _unitOfWork.CommitAsync();
            return serviceDataResponse.CreateServiceResponse<UpdateCategoryResponse>(result, updateCategoryRequest.MapToPaylod(category), _resourceService);
        }
    }
}

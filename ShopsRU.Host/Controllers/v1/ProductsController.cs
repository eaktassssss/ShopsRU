using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Persistence.Implementations.Services;


namespace ShopsRU.Host.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}")]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> CreateAsync(CreateProductRequest createProductRequest)
        {
            var response = await _productService.CreateAsync(createProductRequest);
            return Ok(response);
        }


        [HttpPost]
        [Route("category")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            var response = await _categoryService.CreateAsync(createCategoryRequest);
            return Ok(response);
        }

        [HttpPut]
        [Route("product")]
        public async Task<IActionResult> UpdateAsync(UpdateProductRequest updateProductRequest)
        {
            var response = await _productService.UpdateAsync(updateProductRequest);
            return Ok(response);
        }


        [HttpDelete]
        [Route("product/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var response = await _productService.DeleteAsync(id);
            return Ok(response);
        }
    }
}

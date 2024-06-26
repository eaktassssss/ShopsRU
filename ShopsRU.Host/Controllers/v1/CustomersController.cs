﻿using Asp.Versioning;
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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;


        }
        [HttpPost]
        [Route("customer")]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest createCustomerRequest)
        {

            var response = await _customerService.CreateAsync(createCustomerRequest);
            return Ok(response);
        }
        [HttpGet]
        [Route("customer/{id}")]
        public async Task<IActionResult> GetSingleAsync(string id)
        {
            var response = await _customerService.GetSingleAsync(id);
            return Ok(response);
        }
        [HttpPut]
        [Route("customer")]
        public async Task<IActionResult> UpdateAsync(UpdateCustomerRequest updateCustomerRequest)
        {
            var response = await _customerService.UpdateAsync(updateCustomerRequest);
            return Ok(response);
        }


        [HttpDelete]
        [Route("customer/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var response = await _customerService.DeleteAsync(id);
            return Ok(response);
        }



        [HttpGet]
        [Route("customer")]
        public async Task<IActionResult> SearchAsync([FromQuery] SearchCustomerRequest searchCustomerRequest)
        {
            var response = await _customerService.SearchAsync(searchCustomerRequest);
            return Ok(response);
        }
    }
}

﻿using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Persistence.Implementations.UnitOfWork;

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
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            var response = await _customerService.GetSingleAsync(id);
            return Ok(response);
        }


        [HttpGet]
        [Route("customer")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerService.GetAllAsync();
            return Ok(response);
        }
    }
}

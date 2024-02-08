using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.Interfaces.Services;

namespace ShopsRU.Host.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}")]

    public class DiscountsController : ControllerBase
    {
        ICustomerDiscountService _customerDiscountService;
        public DiscountsController(ICustomerDiscountService customerDiscountService)
        {

            _customerDiscountService = customerDiscountService;
        }
        [HttpPost]
        [Route("discount")]
        public async Task<IActionResult> CreateAsync(CreateDiscountRequest createCustomerDiscountRequest)
        {
            var response = await _customerDiscountService.CreateAsync(createCustomerDiscountRequest);
            return Ok(response);
        }
    }
}

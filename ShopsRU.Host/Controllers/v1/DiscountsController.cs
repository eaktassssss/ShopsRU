using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.CustomerDiscount;
using ShopsRU.Application.Interfaces.Services;

namespace ShopsRU.Host.Controllers
{
    [Route("api/")]
    [ApiController]
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

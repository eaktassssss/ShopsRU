using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Order;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.Interfaces.Services;

namespace ShopsRU.Host.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}")]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> CreateAsync(CreateOrderRequest createOrderRequest)
        {
            var response = await _orderService.CreateAsync(createOrderRequest);
            return Ok(response);
        }
    }
}

using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Invoice;
using ShopsRU.Application.Interfaces.Services;

namespace ShopsRU.Host.Controllers.v2
{
    [ApiController]
    [ApiVersion(2)]
    [Route("api/v{version:ApiVersion}")]
    public class InvoicesController : ControllerBase
    {
        IInvoiceService _invoiceService;
        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost]
        [Route("invoice")]
        public async Task<IActionResult> CreateAsync(CreateInvoiceRequest createInvoiceRequest)
        {
            var response = await _invoiceService.CreateAsync(createInvoiceRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("invoice/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            var response = await _invoiceService.GetSingleAsync(id);
            return Ok(response);
        }
    }
}

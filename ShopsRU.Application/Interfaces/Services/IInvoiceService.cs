using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Invoice;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Invoice;

using ShopsRU.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<ServiceDataResponse<CreateInvoiceResponse>> CreateAsync(CreateInvoiceRequest createInvoiceRequest);
        Task<ServiceDataResponse<GetSingleInvoiceResponse>> GetSingleAsync(int id);
    }
}

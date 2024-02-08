using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Order;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Order;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<ServiceDataResponse<CreateOrderResponse>> CreateAsync(CreateOrderRequest createOrderRequest);
    }
}

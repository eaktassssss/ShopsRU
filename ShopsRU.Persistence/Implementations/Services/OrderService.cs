
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Order;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Order;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;
using ShopsRU.Persistence.Implementations.Repositories;
using StackExchange.Redis;
using System.Reflection.Metadata.Ecma335;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class OrderService : IOrderService
    {
        readonly IDiscountStrategy _discountStrategy;
        readonly IProductRepository _productRepository;
        readonly IOrderRepository _orderRepository;
        readonly IResourceService _resourceService;
        readonly IUnitOfWork _unitOfWork;
        readonly ICustomerRepository _customerRepository;
        readonly ICustomerDiscountRepository _customerDiscountRepository;
        IDiscountService _discountService;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IResourceService resourceService, ICustomerDiscountRepository customerDiscountRepository, IDiscountStrategy discountStrategy, IDiscountService discountService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _resourceService = resourceService;
            _customerDiscountRepository = customerDiscountRepository;
            _discountStrategy = discountStrategy;
            _discountService = discountService;
        }
        public async Task<ServiceDataResponse<CreateOrderResponse>> CreateAsync(CreateOrderRequest createOrderRequest)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == createOrderRequest.CustomerId);
            if (customer == null)
            {
                return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);

            }
            if (createOrderRequest.OrderItemRequest.Count == 0)
            {

                return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.ORDER_ITEM_NOT_FOUND);
            }

            var order = createOrderRequest.MapToEntity();
            foreach (var item in createOrderRequest.OrderItemRequest)
            {
                var product = await _productRepository.GetAsync(x => x.Id == item.ProductId);

                if (!ProductStockCheck(product, item.Quantity))
                    return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.INSUFFICIENT_STOCK);

                if (product != null)
                {
                    order.OrderItems.Add(GetOrderItems(product, order, item));
                    product.StockQuantity -= item.Quantity;
                    await _productRepository.UpdateAsync(product.Id, product);
                }
            }
            order = await _discountService.ProductBasedApplyDiscountAsync(customer, order);
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, createOrderRequest.MapToResponse(order), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
        private bool ProductStockCheck(Product product, int quantity)
        {
            if (product.StockQuantity <= 0 || product.StockQuantity < quantity)
                return false;
            else
                return true;
        }
        private OrderItem GetOrderItems(Product product, ShopsRU.Domain.Entities.Order order, OrderItemRequest orderItemRequest)
        {
            var orderItem = new OrderItem();
            orderItem.ProductId = product.Id;
            orderItem.UnitPrice = product.Price;
            orderItem.OrderId = order.Id;
            orderItem.Quantity = orderItemRequest.Quantity;
            orderItem.LineAmount = product.Price * orderItemRequest.Quantity;
            orderItem.LineDiscountAmount = 0;
            orderItem.Product = product;
            return orderItem;
        }

    }
}


using ShopsRU.Application.Contract.Request.Customer;
using ShopsRU.Application.Contract.Request.Order;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Order;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;


namespace ShopsRU.Persistence.Implementations.Services
{
    public class OrderService : IOrderService
    {
        readonly IProductRepository _productRepository;
        readonly IOrderRepository _orderRepository;
        readonly IResourceService _resourceService;
        readonly IUnitOfWork _unitOfWork;
        readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IResourceService resourceService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateOrderResponse>> CreateAsync(CreateOrderRequest createOrderRequest)
        {

            var customer = await _customerRepository.GetSingleAsync(x => x.Id == createOrderRequest.CustomerId);
            if (customer == null)
            {
                return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);

            }
            if (createOrderRequest.OrderItemRequest.Count == 0)
            {

                return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.ORDER_ITEM_NOT_FOUND);
            }

            var order = createOrderRequest.MapToEntity();
            foreach (var request in createOrderRequest.OrderItemRequest)
            {
                var product = await _productRepository.GetSingleAsync(x => x.Id == request.ProductId);
                if (product != null)
                {
                    var orderItem = new OrderItem();
                    orderItem.ProductId = product.Id;
                    orderItem.UnitPrice = product.Price;
                    orderItem.OrderId = order.Id;
                    orderItem.Quantity = request.Quantity;
                    orderItem.TotalPrice = product.Price * request.Quantity;
                    order.OrderItems.Add(orderItem);
                }
            }
            order.TotalAmount = order.OrderItems.Sum(x => x.TotalPrice);
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return ServiceDataResponse<CreateOrderResponse>.CreateServiceResponse(_resourceService, createOrderRequest.MapToPaylod(order), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
        }
    }
}

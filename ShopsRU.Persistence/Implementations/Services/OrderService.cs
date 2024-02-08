
using ShopsRU.Application.Contract.Request.Order;
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
            ServiceDataResponse<CreateOrderResponse> serviceDataResponse = new ServiceDataResponse<CreateOrderResponse>();
            
            var customer = await _customerRepository.GetSingleAsync(x => x.Id == createOrderRequest.CustomerId);
            if (customer == null)
            {
                return serviceDataResponse.CreateServiceResponse<CreateOrderResponse>(404, _resourceService, Domain.Enums.ResponseMessages.RESOURCE_NOT_FOUND);

            }
            if (createOrderRequest.OrderItemRequest.Count == 0)
            {
                serviceDataResponse.Message = _resourceService.GetResource("ORDER_ITEM_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
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
            var result = await _unitOfWork.CommitAsync();
            switch (result)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = createOrderRequest.MapToPaylod(order);
                    break;

                case false:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                    serviceDataResponse.StatusCode = 500;
                    serviceDataResponse.Success = false;
                    break;
            }
            return serviceDataResponse;
        }
    }
}

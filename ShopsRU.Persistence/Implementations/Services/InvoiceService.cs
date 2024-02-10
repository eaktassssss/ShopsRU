using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Contract.Request.Invoice;
using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Invoice;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Wrappers;
using ShopsRU.Domain.Entities;

using ShopsRU.Persistence.Implementations.Repositories;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class InvoiceService : IInvoiceService
    {

        readonly ICustomerDiscountRepository _customerDiscountRepository;
        readonly IOrderRepository _orderRepository;
        readonly IOrderItemRepository _orderItemRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly ICustomerRepository _customerRepository;
        readonly IInvoiceRepository _invoiceRepository;
        readonly IResourceService _resourceService;
        IDiscountStrategy _discountStrategy;
        public InvoiceService(IResourceService resourceService, IOrderRepository orderRepository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IInvoiceRepository invoiceRepository, IOrderItemRepository orderItemRepository, IDiscountStrategy discountStrategy, ICustomerDiscountRepository customerDiscountRepository)
        {
            _invoiceRepository = invoiceRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _orderItemRepository = orderItemRepository;
            _discountStrategy = discountStrategy;
            _customerDiscountRepository = customerDiscountRepository;
            _resourceService = resourceService;

        }
        public async Task<ServiceDataResponse<CreateInvoiceResponse>> CreateAsync(CreateInvoiceRequest createInvoiceRequest)
        {
            var order = await _orderRepository.GetByIdAsync(createInvoiceRequest.OrderId);
            if (order == null)
            {
                return ServiceDataResponse<CreateInvoiceResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);
            }
            var customer = await _customerRepository.GetByIdAsync(order.CustomerId);
            if (customer == null)
            {
                return ServiceDataResponse<CreateInvoiceResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);
            }



            var discountApplied = await ApplyDiscount(customer, order.Id);
            if (!discountApplied.Success)
            {
                return ServiceDataResponse<CreateInvoiceResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.OPERATION_FAILED);
            }
            else
            {

                var invoice = createInvoiceRequest.MapToEntity(discountApplied.Payload, customer.Id, order.Id);
                await _invoiceRepository.AddAsync(invoice);
                await _unitOfWork.CommitAsync();
                return ServiceDataResponse<CreateInvoiceResponse>.CreateServiceResponse(_resourceService, createInvoiceRequest.MapToPaylod(invoice), Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
            }

        }

        public async Task<ServiceDataResponse<GetSingleInvoiceResponse>> GetSingleAsync(int id)
        {

            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return ServiceDataResponse<GetSingleInvoiceResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);

            }
            GetSingleInvoiceResponse getSingleCustomerResponse = new GetSingleInvoiceResponse();
            return ServiceDataResponse<GetSingleInvoiceResponse>.CreateServiceResponse(_resourceService, getSingleCustomerResponse.MapToPaylod(invoice), Domain.Enums.ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY);
        }
        public async Task<ServiceDataResponse<ApplyDiscountResponse>> ApplyDiscount(Customer customer, int orderId)
        {
            var invoiceExists = await _invoiceRepository.GetSingleAsync(x => x.OrderId == orderId);
            if (invoiceExists != null)
            {
                return ServiceDataResponse<ApplyDiscountResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.ALREADY_EXISTS);

            }
            var customerDiscount = await _customerDiscountRepository.GetAll().Include(x => x.Discounts).FirstOrDefaultAsync(x => x.CustomerTypeId == customer.CustomerTypeId);
            if (customerDiscount != null)
            {

                var discountStrategyRequest = new DiscountStrategyRules();
                discountStrategyRequest.CustomerTypeId = customerDiscount.CustomerTypeId;
                discountStrategyRequest.DiscountRate = customerDiscount.Discounts.DiscountRate;
                discountStrategyRequest.DiscountType = customerDiscount.Discounts.DiscountType;

                var ruleJson = JsonConvert.DeserializeObject<RuleJson>(customerDiscount.RuleJson);
                discountStrategyRequest.RuleJson = new RuleJson() { CustomerAgeYear = ruleJson.CustomerAgeYear, ExcludeCategories = ruleJson.ExcludeCategories, FixedAmount = ruleJson.FixedAmount, FixedDiscountAmount = ruleJson.FixedDiscountAmount, LoyalCustomerDiscountRate = ruleJson.LoyalCustomerDiscountRate, LoyalCustomerPriority = ruleJson.LoyalCustomerPriority };


                var details = await _orderItemRepository.GetAll(x => x.OrderId == orderId).Include(x => x.Product).ToListAsync();
                if (details != null && details.Count > 0)
                {
                    var amountToBeDiscounted = details.Where(x => !ruleJson.ExcludeCategories.Contains(x.Product.CategoryId)).Sum(x => x.TotalPrice);
                    var amountNotBeDiscounted = details.Where(x => ruleJson.ExcludeCategories.Contains(x.Product.CategoryId)).Sum(x => x.TotalPrice);
                    var applyDiscount = _discountStrategy.ApplyDiscount(discountStrategyRequest, customer, amountToBeDiscounted);
                    applyDiscount.TotalAmount= amountToBeDiscounted + amountNotBeDiscounted;
                    return ServiceDataResponse<ApplyDiscountResponse>.CreateServiceResponse(_resourceService, applyDiscount, Domain.Enums.ResponseMessages.OPERATION_SUCCESS);
                }
                else
                {
                    return ServiceDataResponse<ApplyDiscountResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.ORDER_ITEM_NOT_FOUND);
                }
            }
            else
            {
                return ServiceDataResponse<ApplyDiscountResponse>.CreateServiceResponse(_resourceService, Domain.Enums.ResponseMessages.DATA_NOT_FOUND);
            }
        }
    }
}

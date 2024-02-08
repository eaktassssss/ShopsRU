using ShopsRU.Application.Contract.Response.Category;
using ShopsRU.Application.Contract.Response.CustomerDiscount;
using ShopsRU.Application.Contract.Response.Invoice;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Invoice
{
    public class CreateInvoiceRequest
    {
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int BillingUserId { get; set; }



        public CreateInvoiceResponse MapToPaylod(ShopsRU.Domain.Entities.Invoice invoice)
        {
            return new CreateInvoiceResponse { InvoiceDate = invoice.InvoiceDate, InvoiceId = invoice.Id, OrderNo = invoice.OrderId, OrderDate = invoice.Order.OrderDate, CustomerName = string.Concat(invoice.Customer.FirstName, " ", invoice.Customer.LastName), NetAmount = invoice.NetAmount, TotalAmount = invoice.TotalAmount, DiscountAmount = invoice.DiscountAmount };
        }


        public ShopsRU.Domain.Entities.Invoice MapToEntity(ApplyDiscountResponse applyDiscount, int customerId, int orderId)
        {
            return new ShopsRU.Domain.Entities.Invoice()
            {
                InvoiceDate = this.InvoiceDate,
                BillingUserId = this.BillingUserId,
                NetAmount = applyDiscount.NetAmount,
                TotalAmount = applyDiscount.TotalAmount,
                DiscountAmount = applyDiscount.DiscountAmount,
                CustomerId = customerId,
                OrderId = orderId
            };

        }
    }
}

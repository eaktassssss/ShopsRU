using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.Invoice
{
    public class CreateInvoiceResponse
    {
        public string CustomerName { get; set; }
        public int OrderNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime OrderDate { get; set; }
        public int BillingUserName { get; set; }
        public int InvoiceId { get; set; }
    }
}

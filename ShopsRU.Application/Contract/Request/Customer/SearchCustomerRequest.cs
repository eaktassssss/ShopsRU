using ShopsRU.Application.Contract.Common;
using ShopsRU.Application.Contract.Response.Customer;
using ShopsRU.Application.Contract.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Customer
{
    public class SearchCustomerRequest: SearchRequest
    {
        public List<SearchCustomerResponse> MapToResponse(IEnumerable<Domain.Entities.Customer>  customers)
        {
            List<SearchCustomerResponse> searchCustomerResponse = new List<SearchCustomerResponse>();
            foreach (var customer in customers)
            {
                var response = new SearchCustomerResponse
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    JoiningDate = customer.JoiningDate,
                };
                searchCustomerResponse.Add(response);
            }
            return searchCustomerResponse.ToList();
        }
    }
}

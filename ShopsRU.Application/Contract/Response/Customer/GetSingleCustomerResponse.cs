using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Response.Customer
{
    public  class GetSingleCustomerResponse
    {
        public  string Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int CustomerTypeId { get; set; }
        public DateTime CreatedOn { get; set; }

        public GetSingleCustomerResponse MapToResponse(ShopsRU.Domain.Entities.Customer customer)
        {
            return new GetSingleCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CustomerTypeId = customer.CustomerTypeId, CreatedOn = customer.CreatedDate };
        }
    }
}

using ShopsRU.Application.Contract.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Request.Customer
{
    public class UpdateCustomerRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int CustomerTypeId { get; set; }

        public UpdateCustomerResponse MapToResponse(ShopsRU.Domain.Entities.Customer customer)
        {
            return new UpdateCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CustomerTypeId = customer.CustomerTypeId};
        }
        public ShopsRU.Domain.Entities.Customer MapToEntity()
        {
            return new ShopsRU.Domain.Entities.Customer()
            {
                Id = this.Id,
                LastName = this.LastName,
                CustomerTypeId = this.CustomerTypeId,
                JoiningDate = this.JoiningDate,
                FirstName = this.FirstName
            };

        }

    }
}

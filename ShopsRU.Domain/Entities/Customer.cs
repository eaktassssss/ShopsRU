
using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class Customer : BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int CustomerTypeId { get; set; }

        public CustomerType CustomerType { get; set; }

    

    }
}

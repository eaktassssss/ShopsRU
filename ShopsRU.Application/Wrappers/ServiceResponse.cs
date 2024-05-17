using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Wrappers
{
    public  class ServiceResponse
    {
        public string Message { get; set; }
        public bool  Success { get; set; }
        public int StatusCode { get; set; }


    }
}

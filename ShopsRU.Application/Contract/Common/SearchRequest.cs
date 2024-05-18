using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Contract.Common
{
    public class SearchRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string? SearchText { get; set; }
    }
}

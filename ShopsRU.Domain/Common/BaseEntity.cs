using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; } = "EVREN AKTAŞ";
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

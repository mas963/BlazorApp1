using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string WebURL { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

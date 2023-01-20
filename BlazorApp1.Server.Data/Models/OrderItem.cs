using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public virtual User CreatedUser { get; set; }
        public virtual Order Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.DTO
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string WebURL { get; set; }
        public bool IsActive { get; set; }
    }
}

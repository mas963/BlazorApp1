using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}

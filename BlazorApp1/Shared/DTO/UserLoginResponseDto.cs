using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.DTO
{
    public class UserLoginResponseDto
    {
        public string ApiToken { get; set; }
        public UserDto User { get; set; }
    }
}

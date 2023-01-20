using BlazorApp1.Server.Services.Infrastruce;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace BlazorApp1.Server.Services.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasPermission(Guid userId)
        {
            return IsAdmin(userId) || HasPermissionToChange(userId);
        }

        public bool HasPermissionToChange(Guid userId)
        {
            string user_Id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value;

            return Guid.TryParse(user_Id, out Guid result) ? result == userId : false;
        }

        public bool IsAdmin(Guid userId)
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value == "yasar@gmail.com";
        }
    }
}

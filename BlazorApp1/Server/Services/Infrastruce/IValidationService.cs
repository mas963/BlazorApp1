using System;

namespace BlazorApp1.Server.Services.Infrastruce
{
    public interface IValidationService
    {
        public bool IsAdmin(Guid userId);
        public bool HasPermissionToChange(Guid userId);
        public bool HasPermission(Guid userId);
    }
}

using Blazored.LocalStorage;
using System;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Utils
{
    public static class LocalStorageExtension
    {
        public async static Task<Guid> GetUserId(this ILocalStorageService localStorage)
        {
            string userGuid = await localStorage.GetItemAsStringAsync("UserId");

            return Guid.TryParse(userGuid, out Guid UserId) ? UserId : Guid.Empty;
        }

        public static Guid GetUserIdSync(this ISyncLocalStorageService localStorage)
        {
            string userGuid = localStorage.GetItemAsString("UserId");

            return Guid.TryParse(userGuid, out Guid UserId) ? UserId : Guid.Empty;
        }

        public async static Task<string> GetUserEMail(this ILocalStorageService localStorage)
        {
            return await localStorage.GetItemAsStringAsync("email");
        }

        public async static Task<string> GetUserFullName(this ILocalStorageService localStorage)
        {
            return await localStorage.GetItemAsStringAsync("UserFullName");
        }
    }
}

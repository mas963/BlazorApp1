using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Net.Http;

namespace BlazorApp1.Client.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationState _anonymous;
        private readonly HttpClient _client;

        public AuthStateProvider(ILocalStorageService localStorageService, HttpClient client)
        {
            _localStorageService = localStorageService;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _client = client;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string apiToken = await _localStorageService.GetItemAsStringAsync("token");

            if (String.IsNullOrEmpty(apiToken))
                return _anonymous;

            string email = await _localStorageService.GetItemAsStringAsync("email");

            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",apiToken);

            return new AuthenticationState(cp);
        }

        public void NotifyUserLogin(string email)
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(cp));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout(){
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
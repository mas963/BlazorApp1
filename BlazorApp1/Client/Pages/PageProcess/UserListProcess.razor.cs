using BlazorApp1.Client.Utils;
using BlazorApp1.Shared.CustomExceptions;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages.PageProcess
{
    public class UserListProcess : ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        ModalManager ModalManager { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected List<UserDto> userList = new List<UserDto>();

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }

        protected void goCreateUserPage()
        {
            NavigationManager.NavigateTo("/users/add");
        }

        protected void goUpdateUserPage(Guid UserId)
        {
            NavigationManager.NavigateTo("/users/edit/" + UserId);
        }

        protected async Task DeleteUser(Guid id)
        {
            bool confirmed = await ModalManager.ConfirmationAsync("Confirmation", "User will be deleted. Are you sure?");

            if (!confirmed) return;

            try
            {
                bool deleted = await Client.PostGetServiceResponseAsync<bool, Guid>("api/User/Delete", id, true);

                await LoadList();
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("User Deletion Error", ex.Message);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("An Error", ex.Message);
            }
        }

        protected async Task LoadList()
        {
            try
            {
                userList = await Client.GetServiceResponseAsync<List<UserDto>>("api/User/Users", true);
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("Api Exception", ex.Message);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("Exception", ex.Message);
            }
        }
    }
}

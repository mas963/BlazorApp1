using BlazorApp1.Client.Utils;
using BlazorApp1.Shared.CustomExceptions;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages.PageProcess
{
    public class SupplierBusiness : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Inject]
        protected ILocalStorageService LocalStorageSync { get; set; }

        [Inject]
        ModalManager ModalManager { get; set; }

        [Inject]
        IJSRuntime jSRuntime { get; set; }


        protected List<SupplierDto> SupplierList;

        protected override async Task OnInitializedAsync()
        {
            await ReLoadList();
        }

        public void GoCreateSupplier()
        {
            UrlNavigationManager.NavigateTo("/suppliers/add");
        }

        public void GoEditOrder(Guid supplierId)
        {
            UrlNavigationManager.NavigateTo("/suppliers/edit/" + supplierId.ToString());
        }

        public async Task ReLoadList()
        {
            var res = await Http.GetFromJsonAsync<ServiceResponse<List<SupplierDto>>>($"api/Supplier/Suppliers");

            SupplierList = res.Success && res.Value != null ? res.Value : new List<SupplierDto>();
        }

        public async Task DeleteSupplier(Guid supplierId)
        {
            var modalRes = await ModalManager.ConfirmationAsync("Confirm", "Supplier will be deleted. Are you sure?");
            if (!modalRes)
            {
                return;
            }

            try
            {
                var res = await Http.PostGetBaseResponseAsync("api/Supplier/DeleteSupplier", supplierId);

                if (res.Success)
                {
                    SupplierList.RemoveAll(i => i.Id == supplierId);
                }
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("Error", ex.Message);
            }
        }

        public async void GoWebUrl(Uri url)
        {
            await jSRuntime.InvokeAsync<object>("open", url.ToString(), "_blank");
        }

    }
}

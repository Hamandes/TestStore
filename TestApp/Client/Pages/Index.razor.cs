using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TestApp.Client.Services;
using TestApp.Domain.Dtos;

namespace TestApp.Client.Pages
{
    public partial class Index
    {
        [Inject]
        private HttpClient HttpClientService { get; set; }
        [Inject]
        private ToastifyService ToastifyService { get; set; }
        public HttpClient HttpClient { get; private set; }
        private ProductModel[] AllProducts { get; set; }
        private int TotalPages => AllProducts == null ? 0 : (int)Math.Ceiling((double)AllProducts.Length / 2);
        private bool IsLoading { get; set; } = false;
        protected async override Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                HttpClient = HttpClientService;
                AllProducts = await HttpClient.GetFromJsonAsync<ProductModel[]>("Product/ListProducts");
            }
            catch (Exception ex)
            {
                await ToastifyService.DisplayErrorNotification(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

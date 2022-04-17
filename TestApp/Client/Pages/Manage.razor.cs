using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TestApp.Client.Services;
using TestApp.Domain.Dtos;

namespace TestApp.Client.Pages
{ 
    [Route("AddProduct")] 
    public partial class Manage
    {
        [Inject]
        private ToastifyService ToastifyService { get; set; }
        [Inject]
        private HttpClient HttpClient { get; set; }
       
        [Parameter]
        public int? ProductId { get; set; }
        private bool IsEdit => ProductId.HasValue;
        private string PageHeader => IsEdit ? "Edit Product" : "Add Product";
        private ProductModel ProductModel { get; set; } = new ProductModel();
        private HttpClient AuthorizedHttpClient { get; set; }
        private CategoryModel[] AllCategory { get; set; }
        private bool IsLoading { get; set; } = false;
        private bool ShowSelectImageComponent { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            AuthorizedHttpClient = HttpClient;
            AllCategory = await HttpClient.GetFromJsonAsync<CategoryModel[]>("Product/ListCategory");
            if (IsEdit)
            {
                ProductModel = await HttpClient
                    .GetFromJsonAsync<ProductModel>($"Product/GetProductById?productId={ProductId}");
            }
            else
            {
                ProductModel.CategoryId = AllCategory[0].Id;
            }
        }

        private async Task OnValidSubmitAsync()
        {
            try
            {
                IsLoading = true;
                string requestUrl = IsEdit ? "api/Product/EditProduct" : "api/Product/AddProduct";
                var response = await AuthorizedHttpClient
                    .PostAsJsonAsync<ProductModel>(requestUrl, ProductModel);
                if (!response.IsSuccessStatusCode)
                {
             //       var problemHttpResponse = await response.Content.ReadFromJsonAsync<ProblemHttpResponse>();
               //     await ToastifyService.DisplayErrorNotification(problemHttpResponse.Detail);
                }
                else
                {
                    string actionMessage = IsEdit ? "edited" : "created";
                    await ToastifyService.DisplaySuccessNotification($"Product '{ProductModel.Name}' " +
                        $"has been {actionMessage}");
                   // NavigationManager.NavigateTo(Constants.AdminPagesRoutes.ListProducts);

                }
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

        private void OpenSelectImage()
        {
            ShowSelectImageComponent = true;
        }

        private void OnImageSelected(string imageUrl)
        {
            ProductModel.ImageUrl = imageUrl;
            ShowSelectImageComponent = false;
            StateHasChanged();
        }
    }
}

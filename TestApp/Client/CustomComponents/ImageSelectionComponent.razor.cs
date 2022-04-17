using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TestApp.Client.Services;
using TestApp.Domain.Images;

namespace TestApp.Client.CustomComponents
{
    public partial class ImageSelectionComponent
    {
        [Inject]
        private HttpClient HttpClientService { get; set; }
        [Inject]
        private ToastifyService ToastifyService { get; set; }
        private HttpClient AuthorizedHttpClient { get; set; }
        private ImageModel[] AllImages { get; set; }
        [Parameter]
        public Action<string> OnImageSelected { get; set; }
        private bool IsLoading { get; set; }
        protected async override Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true; 
                AllImages = await AuthorizedHttpClient.GetFromJsonAsync<ImageModel[]>("api/Image/ListImages");
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

        private void SelectImage(ImageModel imageModel)
        {
            OnImageSelected(imageModel.ImageUrl);
        }
    }
}

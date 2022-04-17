using Microsoft.AspNetCore.Components; 
namespace TestApp.Client.CustomComponents
{
    public partial class LoadingComponent
    {
        [Parameter]
        public bool IsLoading { get; set; }
    }
}

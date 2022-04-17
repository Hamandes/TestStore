using Microsoft.AspNetCore.Components;

namespace TestApp.Client.CustomComponents
{
    public partial class ConfirmComponent
    {
        [Parameter]
        public Action OkAction { get; set; }
        [Parameter]
        public Action CloseAction { get; set; }
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public RenderFragment BodyContent { get; set; }
        [Parameter]
        public string OkText { get; set; }
        [Parameter]
        public string CloseText { get; set; }
    }
}

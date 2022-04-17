using Microsoft.AspNetCore.Components;

namespace TestApp.Client.CustomComponents
{
    public partial class ProductCard
    {
        [Parameter]
        public RenderFragment Image { get; set; }
        [Parameter]
        public string CardTitle { get; set; }
        [Parameter]
        public string CardBodyText { get; set; }
        [Parameter]
        public bool EnableDelete { get; set; }
        [Parameter]
        public Action DeleteAction { get; set; }
        [Parameter]
        public bool EnableEdit { get; set; }
        [Parameter]
        public Action EditAction { get; set; }
    }
}

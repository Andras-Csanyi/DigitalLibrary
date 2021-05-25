namespace DigitalLibrary.WebUi.FAST.Components.Components.Badge
{
    using Microsoft.AspNetCore.Components;

    public partial class Badge
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Fill { get; set; }

        [Parameter]
        public string Color { get; set; }
    }
}

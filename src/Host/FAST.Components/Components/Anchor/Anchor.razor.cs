namespace DigitalLibrary.WebUi.FAST.Components.Components.Anchor
{
    using Microsoft.AspNetCore.Components;

    public partial class Anchor
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Url { get; set; }
    }
}

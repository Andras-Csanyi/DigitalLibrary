namespace DigitalLibrary.WebUi.FAST.Components.Components.Accordion
{
    using Microsoft.AspNetCore.Components;

    public partial class Accordion
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}

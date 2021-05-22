namespace DigitalLibrary.WebUi.FAST.Components.Components.Accordion
{
    using Microsoft.AspNetCore.Components;

    public partial class AccordionItem
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool IsExpanded { get; set; }

        [Parameter]
        public string Title { get; set; }
    }
}

// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace FAST.Components.Components.TreeView
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    public partial class BfTreeItem
    {
        private string _slot = "item";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Expanded { get; set; }

        [CascadingParameter]
        protected BfTreeView ParentTreeView { get; set; }

        [Parameter]
        public bool Selected { get; set; } = false;

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UnknownParameters { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Selected)
            {
                await Select().ConfigureAwait(false);
            }
        }

        private async Task Select()
        {
            Selected = true;
            await ParentTreeView.Select(this).ConfigureAwait(false);
        }
    }
}
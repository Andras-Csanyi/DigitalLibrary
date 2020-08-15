// <copyright file="BfTreeView.razor.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Components.TreeView
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    public partial class BfTreeView
    {
        private BfTreeItem _selected;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UnknownParameters { get; set; }

        public async Task Select(BfTreeItem item)
        {
            if (_selected != null)
            {
                _selected.Selected = !_selected.Selected;
                _selected = item;
                await InvokeAsync(StateHasChanged).ConfigureAwait(false);
            }
        }
    }
}
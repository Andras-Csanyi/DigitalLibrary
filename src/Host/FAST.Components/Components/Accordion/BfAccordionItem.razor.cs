// <copyright file="BfAccordionItem.razor.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Components.Accordion
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    ///     BfAccordionItem Component.
    /// </summary>
    public partial class BfAccordionItem
    {
        /// <summary>
        ///     Content of the component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Configures whether the component is expanded or not.
        /// </summary>
        [Parameter]
        public bool IsExpanded { get; set; }

        /// <summary>
        ///     Any other attribute the component have will be processes by Blazor.
        ///     This process is described in its Attribute Splatting section.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UnknownParameters { get; set; }

        private void ExpandOperation()
        {
            IsExpanded = !IsExpanded;
        }
    }
}
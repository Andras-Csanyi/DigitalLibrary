// <copyright file="BfAccordionItemContent.razor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FAST.Components.Components.Accordion
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    ///     BfAccordionItemContent component.
    /// </summary>
    public partial class BfAccordionItemContent
    {
        /// <summary>
        ///     The content of the component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Any other attribute the component have will be processes by Blazor.
        ///     This process is described in its Attribute Splatting section.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UnknownParameters { get; set; }
    }
}
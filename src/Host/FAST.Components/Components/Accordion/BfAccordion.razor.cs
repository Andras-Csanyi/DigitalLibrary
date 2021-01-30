// <copyright file="BfAccordion.razor.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Components.Accordion
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    ///     BfAccordion component
    ///     It is the top most element of a accordion component.
    /// </summary>
    public partial class BfAccordion
    {
        private string _expandModel = BfComponentApis.BfAccordion.ExpandModeValues.Multi;

        /// <summary>
        ///     The content of the component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Defines whether the accordion is single or multiple expand mode.
        ///     It can be configured using <see cref="BfComponentApis.BfAccordion.ExpandMode" />
        ///     and the Api values <see cref="BfComponentApis.BfAccordion.ExpandModeValues" />
        /// </summary>
        [Parameter]
        public string ExpandMode { get; set; }

        /// <summary>
        ///     Any other attribute of the component. Blazor processes these according to the
        ///     attribute splatting doc.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> UnknownParameters { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await SetExpandMode().ConfigureAwait(false);
        }

        private async Task SetExpandMode()
        {
            if (!string.IsNullOrEmpty(ExpandMode) && !string.IsNullOrWhiteSpace(ExpandMode))
            {
                switch (ExpandMode)
                {
                    case BfComponentApis.BfAccordion.ExpandModeValues.Multi:
                        _expandModel = BfComponentApis.BfAccordion.ExpandModeValues.Multi;
                        break;

                    case BfComponentApis.BfAccordion.ExpandModeValues.Single:
                        _expandModel = BfComponentApis.BfAccordion.ExpandModeValues.Single;
                        break;
                }
            }
        }
    }
}
// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace FAST.Components.Components.Accordion
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    /// <summary>
    ///     BfAccordionItemHeading component.
    /// </summary>
    public partial class BfAccordionItemHeading
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
        public IDictionary<string, object> UnknownParameters { get; set; }
    }
}
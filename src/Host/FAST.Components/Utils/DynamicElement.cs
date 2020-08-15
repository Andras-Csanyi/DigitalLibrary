// <copyright file="DynamicElement.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Utils
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    /// <summary>
    ///     Renders a HTML element with the name and attributes.
    /// </summary>
    public class DynamicElement : ComponentBase
    {
        /// <summary>
        ///     Content of the HTML element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     Reference to other components
        /// </summary>
        [Parameter]
        public ElementReference ElementReference { get; set; }

        [Parameter]
        public Action<ElementReference> ElementReferenceChanged { get; set; }

        /// <summary>
        ///     Elements are not named as properties
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> MyParams { get; set; }

        /// <summary>
        ///     Name of the element
        /// </summary>
        [Parameter]
        public string TagName { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            if (builder != null)
            {
                builder.OpenElement(0, TagName);
                builder.AddMultipleAttributes(1, MyParams);
                builder.AddContent(3, ChildContent);
                builder.AddElementReferenceCapture(2, capturedRef =>
                {
                    ElementReference = capturedRef;
                    ElementReferenceChanged?.Invoke(ElementReference);
                });
                builder.CloseElement();
            }
        }
    }
}
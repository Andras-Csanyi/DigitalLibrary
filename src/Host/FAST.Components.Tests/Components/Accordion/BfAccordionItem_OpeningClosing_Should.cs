// <copyright file="BfAccordionItem_OpeningClosing_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Tests.Components.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using AngleSharp.Dom;

    using Bunit;

    using FAST.Components.Components.Accordion;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ExcludeFromCodeCoverage]
    public class BfAccordionItem_OpeningClosing_Should : TestContext
    {
        [Fact]
        public void Change_ExpandedCollapsedState()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>());

            IElement accordionItem = cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}");

            // Act
            accordionItem.Click();

            // Assert
            accordionItem.Attributes.GetNamedItem("expanded").Should().NotBeNull();
        }
    }
}
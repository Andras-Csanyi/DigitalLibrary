// <copyright file="BfAccordionItemContent_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Tests.Components.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using AngleSharp.Dom;
    using Bunit;
    using FAST.Components.Components.Accordion;
    using FluentAssertions;
    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class BfAccordionItemContent_Should : TestContext
    {
        [Fact]
        public void SplatUnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    pp => pp.AddChildContent<BfAccordionItemContent>(
                        ppp => { ppp.AddUnmatched("custom", "value"); })));

            // Assert
            IAttr attr = cut.Find($"{FastHtmlElements.FastAccordion}>" +
                    $"{FastHtmlElements.FastAccordionItem}>" +
                    $"div")
               .Attributes
               .GetNamedItem("custom");
            attr.Value.Should().Be("value");
        }

        [Fact]
        public void WrapContent()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    pp => pp.AddChildContent<BfAccordionItemContent>(
                        ppp => ppp.AddChildContent("content"))));

            // Assert
            cut.Find($"{FastHtmlElements.FastAccordion}>" +
                    $"{FastHtmlElements.FastAccordionItem}>" +
                    $"div")
               .InnerHtml
               .Contains("content")
               .Should()
               .BeTrue();
        }
    }
}
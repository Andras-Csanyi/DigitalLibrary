// <copyright file="BfAccordionItemContent_Should.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
    public class BfAccordionItemContent_Should : TestContext
    {
        [Fact]
        public void SplatUnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    pp => pp.AddChildContent<BfAccordionItemContent>(
                        ppp => { ppp.AddUnmatched("custom", "value"); }
                    )
                )
            );

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
                        ppp => ppp.AddChildContent("content")
                    )
                )
            );

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
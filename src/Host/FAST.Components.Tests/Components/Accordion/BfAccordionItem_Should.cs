// <copyright file="BfAccordionItem_Should.cs" company="Andras Csanyi">
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

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class BfAccordionItem_Should : TestContext
    {
        [Fact]
        public void BeClosed_ByDefault()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>());

            // Assert
            cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}")
               .ClassList.Length.Should().Be(0);
        }

        [Fact]
        public void BeOpened_WhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(pp => pp.Add(
                    ppp => ppp.IsExpanded, true)));

            // Assert
            IAttr attr = cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}")
               .Attributes
               .GetNamedItem("expanded");
            attr.Should().NotBeNull();
        }

        [Fact]
        public void Splat_UnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    ppp => ppp.AddUnmatched("custom", "value")));

            // Assert
            IAttr attr = cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}")
               .Attributes
               .GetNamedItem("custom");
            attr.Should().NotBeNull();
            attr.Value.Should().Be("value");
        }
    }
}
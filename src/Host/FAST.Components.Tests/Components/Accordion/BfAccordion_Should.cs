// <copyright file="BfAccordion_Should.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FAST.Components.Tests.Components.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using AngleSharp.Dom;

    using Bunit;

    using FAST.Components.Components;
    using FAST.Components.Components.Accordion;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ExcludeFromCodeCoverage]
    public class BfAccordion_Should : TestContext
    {
        [Fact]
        public void Have_ExpandMode_Attribute_SetToMulti_ByDefault()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>();

            // Asset
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
               .Attributes
               .GetNamedItem(FastHtmlElements.FastAccordionAttributes.ExpandMode);

            attr.Should().NotBeNull();
        }

        [Fact]
        public void Have_ExpandMode_Attribute_SetToMulti_WhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.Add(pp => pp.ExpandMode, BfComponentApis.BfAccordion.ExpandModeValues.Multi));

            // Asset
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
               .Attributes
               .GetNamedItem(FastHtmlElements.FastAccordionAttributes.ExpandMode);

            attr.Should().NotBeNull();
        }

        [Fact]
        public void Have_ExpandMode_Attribute_SetToSingle_WhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.Add(pp => pp.ExpandMode, BfComponentApis.BfAccordion.ExpandModeValues.Single));

            // Asset
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
               .Attributes
               .GetNamedItem(FastHtmlElements.FastAccordionAttributes.ExpandMode);

            attr.Should().NotBeNull();
        }

        [Fact]
        public void HaveNoCssClasses()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>();

            // Assert
            cut.Find(FastHtmlElements.FastAccordion)
               .ClassList.Length
               .Should()
               .Be(0);
        }

        [Fact]
        public void SplatUnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                ("custom", "value"));

            // Assert
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
               .Attributes
               .GetNamedItem("custom");
            attr.Should().NotBeNull();
            attr.Value.Should().Be("value");
        }
    }
}
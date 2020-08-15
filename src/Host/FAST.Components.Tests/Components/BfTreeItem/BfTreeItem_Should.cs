// <copyright file="BfTreeItem_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Tests.Components.BfTreeItem
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Bunit;
    using FAST.Components.Components;
    using FAST.Components.Components.TreeView;
    using FluentAssertions;
    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class BfTreeItem_Should : TestContext
    {
        [Fact]
        public void Render_FastTreeItem_Tag()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>());

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .Should()
               .NotBeNull();
        }

        [Fact]
        public void RenderChildContent()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => { pa.AddChildContent<BfTreeItem>(); }));

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .ToMarkup()
               .Contains(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .Should()
               .BeTrue();
        }

        [Fact]
        public void Splat_Attribute()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => pa.AddUnmatched("custom", "value")));

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .Attributes
               .GetNamedItem("custom")
               .Value
               .Should()
               .Be("value");
        }

        [Fact]
        public void Splat_Attributes()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa =>
                    {
                        pa.AddUnmatched("custom", "value");
                        pa.AddUnmatched("custom2", "value2");
                    }));

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .Attributes
               .GetNamedItem("custom")
               .Value
               .Should()
               .Be("value");

            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .Attributes
               .GetNamedItem("custom2")
               .Value
               .Should()
               .Be("value2");
        }
    }
}
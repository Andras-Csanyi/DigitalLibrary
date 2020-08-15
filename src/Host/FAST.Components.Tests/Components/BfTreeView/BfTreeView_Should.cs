// <copyright file="BfTreeView_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Tests.Components.BfTreeView
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
    public class BfTreeView_Should : TestContext
    {
        [Fact]
        public void Generate_FastTreeView_HtmlItem()
        {
            // Act
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>();

            // Assert
            cut.Find(BfComponentApis.BfTreeView.Html.BfTreeView)
               .Should().NotBeNull();
        }

        [Fact]
        public void RenderChildContent()
        {
            // Act
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>()
            );

            // Assert
            cut.Find(BfComponentApis.BfTreeView.Html.BfTreeView)
               .ToMarkup()
               .Contains(BfComponentApis.BfTreeItem.Html.BfTreeItem)
               .Should()
               .BeTrue();
        }

        [Fact]
        public void SplatAttribute()
        {
            // Act
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                ("custom", "value"));

            // Assert
            cut.Find(BfComponentApis.BfTreeView.Html.BfTreeView)
               .Attributes
               .GetNamedItem("custom")
               .Value
               .Should()
               .Be("value");
        }

        [Fact]
        public void SplatMultipleAttributes()
        {
            // Act
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                ("custom", "value"),
                ("custom2", "value2")
            );

            // Assert
            cut.Find(BfComponentApis.BfTreeView.Html.BfTreeView)
               .Attributes
               .GetNamedItem("custom")
               .Value
               .Should()
               .Be("value");

            cut.Find(BfComponentApis.BfTreeView.Html.BfTreeView)
               .Attributes
               .GetNamedItem("custom2")
               .Value
               .Should()
               .Be("value2");
        }
    }
}
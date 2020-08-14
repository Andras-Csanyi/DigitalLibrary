// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace FAST.Components.Tests.Components.BfTreeView
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using AngleSharp.Dom;

    using Bunit;

    using FAST.Components.Components;
    using FAST.Components.Components.TreeView;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ExcludeFromCodeCoverage]
    public class BfTreeItem_ExpandedCollapsed_Should : TestContext
    {
        [Fact]
        public void BeClosedByDefault()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>()
            );

            // Assert
            INamedNodeMap attrs = cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem).Attributes;
            attrs.GetNamedItem(BfComponentApis.BfTreeItem.Attributes.Expanded)
               .Should().BeNull();
        }

        [Fact]
        public void BeClosedWhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => { pa.Add(b => b.Expanded, false); })
            );

            // Assert
            INamedNodeMap attrs = cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem).Attributes;
            attrs.GetNamedItem(BfComponentApis.BfTreeItem.Attributes.Expanded)
               .Should().BeNull();
        }

        [Fact]
        public void BeOpenWhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => { pa.Add(b => b.Expanded, true); })
            );

            // Assert
            INamedNodeMap attrs = cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem).Attributes;
            attrs.GetNamedItem(BfComponentApis.BfTreeItem.Attributes.Expanded)
               .Should().NotBeNull();
        }
    }
}
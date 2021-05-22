namespace DigitalLibrary.WebUi.FAST.Components.Tests.Components.Anchor
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Bunit;

    using DigitalLibrary.WebUi.FAST.Components.Components.Anchor;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Anchor_Should
    {
        [Fact]
        public async Task GenerateTheRightHtml_WithoutAnyParameters()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Anchor> cut = ctx.RenderComponent<Anchor>();

            // Assert
            cut.MarkupMatches("<fast-anchor appearance=\"hypertext\"></fast-anchor>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithUrlParameter()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Anchor> cut = ctx.RenderComponent<Anchor>(
                parameters => parameters.Add(p => p.Url, "http://example.com"));

            // Assert
            cut.MarkupMatches("<fast-anchor href=\"http://example.com\" appearance=\"hypertext\"></fast-anchor>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithChildContent()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Anchor> cut = ctx.RenderComponent<Anchor>(
                parameters => parameters.AddChildContent("childcontent"));

            // Assert
            cut.MarkupMatches("<fast-anchor appearance=\"hypertext\">childcontent</fast-anchor>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithAllParams()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Anchor> cut = ctx.RenderComponent<Anchor>(
                parameters => parameters
                   .AddChildContent("childcontent")
                   .Add(p => p.Url, "http://example.com"));

            // Assert
            cut.MarkupMatches(
                "<fast-anchor href=\"http://example.com\" appearance=\"hypertext\">childcontent</fast-anchor>");
        }
    }
}

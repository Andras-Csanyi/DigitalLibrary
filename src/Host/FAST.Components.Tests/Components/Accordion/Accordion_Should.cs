namespace DigitalLibrary.WebUi.FAST.Components.Tests.Components.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Bunit;

    using DigitalLibrary.WebUi.FAST.Components.Components.Accordion;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Accordion_Should
    {
        [Fact]
        public async Task GenerateTheRightHtml()
        {
            // Arrange
            using TestContext ctx = new TestContext();

            // Act
            IRenderedComponent<Accordion> cut = ctx.RenderComponent<Accordion>();

            // Assert
            cut.MarkupMatches("<fast-accordion></fast-accordion>");
        }

        [Fact]
        public async Task GenerateTheRightHtmlWithContent()
        {
            // Arrange
            using TestContext ctx = new TestContext();

            // Act
            IRenderedComponent<Accordion> cut = ctx.RenderComponent<Accordion>(
                parameters => parameters.AddChildContent("childcontent"));

            // Assert
            cut.MarkupMatches("<fast-accordion>childcontent</fast-accordion>");
        }
    }
}

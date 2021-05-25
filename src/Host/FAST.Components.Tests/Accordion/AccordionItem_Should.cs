namespace DigitalLibrary.WebUi.FAST.Components.Tests.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Bunit;

    using DigitalLibrary.WebUi.FAST.Components.Components.Accordion;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AccordionItem_Should
    {
        [Fact]
        public async Task GenerateTheRightHtml()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<AccordionItem> cut = ctx.RenderComponent<AccordionItem>();

            // Assert
            cut.MarkupMatches("<fast-accordion-item><span slot=\"heading\"></span></fast-accordion-item>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithChildContent()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<AccordionItem> cut = ctx.RenderComponent<AccordionItem>(
                parameters => parameters.AddChildContent("childcontent"));

            // Assert
            cut.MarkupMatches("<fast-accordion-item><span slot=\"heading\"></span>childcontent</fast-accordion-item>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithTitle()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<AccordionItem> cut = ctx.RenderComponent<AccordionItem>(
                parameters => parameters
                   .Add(p => p.Title, "title"));

            // Assert
            cut.MarkupMatches("<fast-accordion-item><span slot=\"heading\">title</span></fast-accordion-item>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithTitleAndChildContent()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<AccordionItem> cut = ctx.RenderComponent<AccordionItem>(
                parameters => parameters
                   .Add(p => p.Title, "title")
                   .AddChildContent("childcontent"));

            // Assert
            cut.MarkupMatches(
                "<fast-accordion-item><span slot=\"heading\">title</span>childcontent</fast-accordion-item>");
        }

        [Fact]
        public async Task GenerateTheRightHtml_WithExpandedTrue()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<AccordionItem> cut = ctx.RenderComponent<AccordionItem>(
                parameters => parameters
                   .Add(p => p.Title, "title")
                   .AddChildContent("childcontent")
                   .Add(p => p.IsExpanded, true));

            // Assert
            cut.MarkupMatches(
                "<fast-accordion-item expanded><span slot=\"heading\">title</span>childcontent</fast-accordion-item>");
        }
    }
}

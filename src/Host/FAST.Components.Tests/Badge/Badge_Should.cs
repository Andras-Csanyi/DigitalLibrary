namespace DigitalLibrary.WebUi.FAST.Components.Tests.Badge
{
    using System.Diagnostics.CodeAnalysis;

    using Bunit;

    using DigitalLibrary.WebUi.FAST.Components.Components.Badge;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Badge_Should
    {
        [Fact]
        public void Generate_ProperHtml_WhenNoParamsSetUp()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Badge> cut = ctx.RenderComponent<Badge>();

            // Assert
            cut.MarkupMatches("<fast-badge></fast-badge>");
        }

        [Fact]
        public void Generate_ProperHtml_WhenChildContentIsProvided()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Badge> cut = ctx.RenderComponent<Badge>(
                p => p.AddChildContent("child-content"));

            // Assert
            cut.MarkupMatches("<fast-badge>child-content</fast-badge>");
        }

        [Fact]
        public void Generate_ProperHtml_WhenChildContentIs_AndColor_AreProvided()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Badge> cut = ctx.RenderComponent<Badge>(
                p => p.AddChildContent("child-content")
                   .Add(pr => pr.Color, ComponentApis.Badge.Color.White)
                );

            // Assert
            cut.MarkupMatches("<fast-badge color=\"white\">child-content</fast-badge>");
        }

        [Fact]
        public void Generate_ProperHtml_WhenChildContentIs_AndColorAndFill_AreProvided()
        {
            // Arrange
            using TestContext ctx = new ();

            // Action
            IRenderedComponent<Badge> cut = ctx.RenderComponent<Badge>(
                p => p.AddChildContent("child-content")
                   .Add(pr => pr.Color, ComponentApis.Badge.Color.White)
                   .Add(pii => pii.Fill, ComponentApis.Badge.Fill.Primary)
            );

            // Assert
            cut.MarkupMatches("<fast-badge color=\"white\" fill=\"primary\">child-content</fast-badge>");
        }
    }
}

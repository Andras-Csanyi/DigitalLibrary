namespace WebUI.Test.SourceFormatBuilder
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    public class Init_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            ISourceFormatBuilderService builder = new SourceFormatBuilderService(_masterDataWebApiClientMock.Object);

            // Act
            Func<Task> action = async () => { await builder.Init(0).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
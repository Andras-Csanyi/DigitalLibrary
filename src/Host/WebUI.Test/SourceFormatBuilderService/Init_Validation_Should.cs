namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Init_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            ISourceFormatBuilderService builder = new SourceFormatBuilderService(_masterDataWebApiClientMock.Object);

            // Act
            Func<Task> action = async () => { await builder.OnUpdate(0).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
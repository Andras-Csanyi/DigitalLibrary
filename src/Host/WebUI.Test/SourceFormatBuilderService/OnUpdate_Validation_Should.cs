namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Utils.Guards;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class OnUpdate_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            ISourceFormatBuilderService builder = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            // Act
            Func<Task> action = async () => { await builder.OnUpdate(0).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
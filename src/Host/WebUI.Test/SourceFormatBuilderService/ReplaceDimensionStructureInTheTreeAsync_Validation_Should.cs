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
    public class ReplaceDimensionStructureInTheTreeAsync_Validation_Should : TestBase
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public async Task ThrowException_WhenInputIsInvalid(long oldValue, long newValue)
        {
            // Arrange
            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);

            // Act
            Func<Task> action = async () =>
            {
                await builderService.ReplaceDimensionStructureInTheTree(oldValue, newValue)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactlyAsync<GuardException>();
        }
    }
}
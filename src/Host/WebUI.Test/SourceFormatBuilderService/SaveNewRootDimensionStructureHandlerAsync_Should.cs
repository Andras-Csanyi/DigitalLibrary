namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    public class SaveNewRootDimensionStructureHandlerAsync_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange
            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object);

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(
                        null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }

        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
        }

        [Fact]
        public async Task AddItWithoutDimension_AsRootDimensionStructure()
        {
        }

        [Fact]
        public async Task AddItWithDimension_AsRootDimensionStructure()
        {
        }
    }
}
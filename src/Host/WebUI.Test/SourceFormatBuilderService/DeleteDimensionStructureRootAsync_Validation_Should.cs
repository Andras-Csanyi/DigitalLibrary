namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class DeleteDimensionStructureRootAsync_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormatWithoutRootDimensionStructure);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object);
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "Something root",
                Desc = "Something root description",
                IsActive = 1
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.DeleteDimensionStructureRootAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public async Task ThrowException_WhenSourceFormatIsNull()
        {
            // Arrange
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object);
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "Something root",
                Desc = "Something root description",
                IsActive = 1,
            };

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.DeleteDimensionStructureRootAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }
    }
}
namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MasterData.DomainModel;

    using Moq;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AddDimensionStructureRootAsync_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_SourceFormatHasRootDimensionStructure()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            DimensionStructure dimensionStructure = new DimensionStructure();

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);
                await sourceFormatBuilderService.AddDimensionStructureRootAsync(
                    dimensionStructure).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }

        [Fact]
        public async Task AddDimensionStructureToRoot()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormatWithoutRootDimensionStructure);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "Something root",
                Desc = "Something root description",
                IsActive = 1
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddDimensionStructureRootAsync(dimensionStructure).ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Should().NotBeNull();
            sourceFormatBuilderService.SourceFormat.RootDimensionStructureId.Should().NotBeNull();
        }
    }
}
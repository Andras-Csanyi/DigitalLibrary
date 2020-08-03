namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MasterData.DomainModel;

    using Moq;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class DeleteDimensionStructureRootAsync_Should : TestBase
    {
        [Fact]
        public async Task SetRootDimensionStructure_To_Null()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "Something root",
                Desc = "Something root description",
                IsActive = 1,
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.DeleteDimensionStructureRootAsync(
                    dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Should().BeNull();
            sourceFormatBuilderService.SourceFormat.RootDimensionStructureId.Should().BeNull();
        }
    }
}
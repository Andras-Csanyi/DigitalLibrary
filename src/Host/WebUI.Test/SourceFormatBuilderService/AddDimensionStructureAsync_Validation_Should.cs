namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AddDimensionStructureAsync_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_When_ParentIdIsZero()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.AddDimensionStructureAsync(11, null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public async Task ThrowException_When_DimensionStructureParamIsNull()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);
            DimensionStructure dimensionStructure = new DimensionStructure();
            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.AddDimensionStructureAsync(0, dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
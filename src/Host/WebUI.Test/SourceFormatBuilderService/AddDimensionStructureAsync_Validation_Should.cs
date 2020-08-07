namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MasterData.DomainModel;

    using Moq;

    using Utils.Guards;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "SA1600")]
    [SuppressMessage("ReSharper", "SA1404")]
    public class AddDimensionStructureAsync_Validation_Should : TestBase
    {
        [Fact]
        public async Task ThrowException_When_DimensionStructureParamIsNull()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
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

        [Fact]
        public async Task ThrowException_When_ParentIdIsZero()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);
            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.AddDimensionStructureAsync(11, null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
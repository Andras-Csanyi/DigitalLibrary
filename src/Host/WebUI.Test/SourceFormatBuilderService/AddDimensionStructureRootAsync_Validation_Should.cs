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
    public class AddDimensionStructureRootAsync_Validation_Should : TestBase
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

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);
                await sourceFormatBuilderService.AddDimensionStructureRootAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators.TestData;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;

    using FluentAssertions;

    using FluentValidation;

    using Xunit;

    [SuppressMessage("ReSharper", "xUnit1015")]
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


        [Theory]
        [InlineData(0, "", "desc", 1)]
        [InlineData(0, null, "desc", 1)]
        [InlineData(0, "na", "desc", 1)]
        [InlineData(0, "name", "", 1)]
        [InlineData(0, "name", null, 1)]
        [InlineData(0, "name", "de", 1)]
        [InlineData(0, "name", "desc", 2)]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                GetMasterDataValidators());

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Act
            Func<Task> action = async () =>
            {
                await sourceFormatBuilderService.SaveNewRootDimensionStructureHandlerAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>()
               .WithInnerException<ValidationException>();
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
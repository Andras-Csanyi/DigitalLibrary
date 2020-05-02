namespace WebUI.Test.SourceFormatBuilderService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
    using DigitalLibrary.Ui.WebUi.Services;

    using FluentAssertions;

    using Moq;

    using Xunit;

    public class AddDocumentStructureToTreeAsync_Should : TestBase
    {
        [Fact]
        public async Task AddItem_ToRootDimension()
        {
            // Arrange
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 101,
                Name = "101",
                Desc = "101",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            SourceFormat testData = new SourceFormat
            {
                Id = 100,
                Name = "name",
                Desc = "desc",
                RootDimensionStructure = rootDimensionStructure,
                RootDimensionStructureId = rootDimensionStructure.Id,
            };
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(
                    It.IsAny<SourceFormat>()))
               .ReturnsAsync(testData);

            DimensionStructure addedDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "name",
                Desc = "desc",
            };
            _masterDataWebApiClientMock.Setup(m => m.GetDimensionStructureByIdAsync(
                    It.IsAny<DimensionStructureQueryObject>()))
               .ReturnsAsync(addedDimensionStructure);

            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddDocumentStructureToTreeAsync(200, 101).ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.Should().NotBeNull();
            sourceFormatBuilderService.SourceFormat.Id.Should().Be(testData.Id);
            sourceFormatBuilderService.SourceFormat.Name.Should().Be(testData.Name);
            sourceFormatBuilderService.SourceFormat.Desc.Should().Be(testData.Desc);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Name
               .Should().Be(rootDimensionStructure.Name);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Desc
               .Should().Be(rootDimensionStructure.Desc);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Should().NotBeEmpty();
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(m => m.Id == addedDimensionStructure.Id).ToList().Count.Should().Be(1);
        }

        [Fact]
        public async Task AddItemTo_FirstLevel_EmptyLengthList()
        {
            // Arrange
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 101,
                Name = "101",
                Desc = "101",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            SourceFormat testData = new SourceFormat
            {
                Id = 100,
                Name = "name",
                Desc = "desc",
                RootDimensionStructure = rootDimensionStructure,
                RootDimensionStructureId = rootDimensionStructure.Id,
            };
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(
                    It.IsAny<SourceFormat>()))
               .ReturnsAsync(testData);

            DimensionStructure addedToRoot = new DimensionStructure
            {
                Id = 200,
                Name = "Add by mock",
                Desc = "Added by mock desc",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            _masterDataWebApiClientMock
               .Setup(m => m.GetDimensionStructureByIdAsync(It.IsAny<DimensionStructureQueryObject>()))
               .ReturnsAsync(addedToRoot);

            SourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object);
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Adding to root level
            await sourceFormatBuilderService.AddDocumentStructureToTreeAsync(200, 101).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddDocumentStructureToTreeAsync(201, 200).ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.Should().NotBeNull();
            sourceFormatBuilderService.SourceFormat.Id.Should().Be(testData.Id);
            sourceFormatBuilderService.SourceFormat.Name.Should().Be(testData.Name);
            sourceFormatBuilderService.SourceFormat.Desc.Should().Be(testData.Desc);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Name
               .Should().Be(rootDimensionStructure.Name);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure.Desc
               .Should().Be(rootDimensionStructure.Desc);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Should().NotBeEmpty();
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(m => m.Id == addedToRoot.Id).ToList().Count.Should().Be(1);
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .FirstOrDefault(m => m.Id == addedToRoot.Id)
               .ChildDimensionStructures.Count.Should().Be(1);
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_FirstLevel_ListHasMultipleItems()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_SecondLevel_EmptyList()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_SecondLevel_LastHasMultipleItems()
        {
        }

        /// <summary>
        /// Until this: https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        /// is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_WhenAnItemIsAdded()
        {
        }
    }
}
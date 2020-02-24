namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class RemoveItemFromTreeAsync_Should : TestBase
    {
        [Fact]
        public async Task RemoveRootDimensionStructure()
        {
            // Arrange
            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);

            // Act
            Func<Task> action = async () =>
            {
                await builderService.DeleteDocumentStructureFromTreeAsync(0).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public async Task RemoveItem_WhenOnlyASingleItemIsOnTheFirstLevel()
        {
            // Arrange
            DimensionStructure firstLevelFirst = new DimensionStructure
            {
                Id = 101,
                Name = "one oh one",
                Desc = "one oh one",
            };
            List<DimensionStructure> childDimensionStructures = new List<DimensionStructure>
            {
                firstLevelFirst,
            };
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "root",
                Desc = "root",
                ChildDimensionStructures = childDimensionStructures,
            };
            SourceFormat testData = new SourceFormat
            {
                Id = 100,
                Name = "test",
                Desc = "test desc",
                RootDimensionStructureId = 100,
                RootDimensionStructure = rootDimensionStructure,
            };

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(testData);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync(101).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();
            builderService.SourceFormat.Id.Should().Be(testData.Id);
            builderService.SourceFormat.Name.Should().Be(testData.Name);
            builderService.SourceFormat.Desc.Should().Be(testData.Desc);

            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(0);
        }

        [Fact]
        public async Task RemoveItem_WhenMultipleItemsOnTheFirstLevel()
        {
            // Arrange
            DimensionStructure firstLevelFirst = new DimensionStructure
            {
                Id = 101,
                Name = "one oh one",
                Desc = "one oh one",
            };
            DimensionStructure firstLevelSecond = new DimensionStructure
            {
                Id = 102,
                Name = "two oh one",
                Desc = "two oh two"
            };
            List<DimensionStructure> childDimensionStructures = new List<DimensionStructure>
            {
                firstLevelFirst,
                firstLevelSecond
            };
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "root",
                Desc = "root",
                ChildDimensionStructures = childDimensionStructures,
            };
            SourceFormat testData = new SourceFormat
            {
                Id = 100,
                Name = "test",
                Desc = "test desc",
                RootDimensionStructureId = 100,
                RootDimensionStructure = rootDimensionStructure,
            };

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(testData);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync(101).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();
            builderService.SourceFormat.Id.Should().Be(testData.Id);
            builderService.SourceFormat.Name.Should().Be(testData.Name);
            builderService.SourceFormat.Desc.Should().Be(testData.Desc);

            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault().Id.Should().Be(firstLevelSecond.Id);
        }

        [Fact]
        public async Task RemoveItemWithItsChildren_WhenMultipleItemsOnTheFirstLevel_AndOneOfThemHasChild()
        {
            // Arrange
            DimensionStructure secondLevelFirst = new DimensionStructure
            {
                Id = 201,
                Name = "two oh one",
                Desc = "two oh one",
            };
            DimensionStructure secondLevelSecond = new DimensionStructure
            {
                Id = 202,
                Name = "two oh two",
                Desc = "two oh two",
            };
            DimensionStructure firstLevelThird = new DimensionStructure
            {
                Id = 103,
                Name = "one of three",
                Desc = "one oh three",
                ChildDimensionStructures = new List<DimensionStructure>
                {
                    secondLevelFirst,
                    secondLevelSecond
                },
            };
            DimensionStructure firstLevelFirst = new DimensionStructure
            {
                Id = 101,
                Name = "one oh one",
                Desc = "one oh one",
            };
            DimensionStructure firstLevelSecond = new DimensionStructure
            {
                Id = 102,
                Name = "two oh two",
                Desc = "two oh two",
            };
            List<DimensionStructure> childDimensionStructures = new List<DimensionStructure>
            {
                firstLevelFirst,
                firstLevelSecond,
                firstLevelThird,
            };
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "root",
                Desc = "root",
                ChildDimensionStructures = childDimensionStructures,
            };
            SourceFormat testData = new SourceFormat
            {
                Id = 100,
                Name = "test",
                Desc = "test desc",
                RootDimensionStructureId = 100,
                RootDimensionStructure = rootDimensionStructure,
            };

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(testData);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync(103).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();
            builderService.SourceFormat.Id.Should().Be(testData.Id);
            builderService.SourceFormat.Name.Should().Be(testData.Name);
            builderService.SourceFormat.Desc.Should().Be(testData.Desc);

            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(2);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(p => p.Id == firstLevelFirst.Id).ToList().Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(p => p.Id == firstLevelSecond.Id).ToList().Count.Should().Be(1);
        }

        [Fact]
        public async Task RemoveItem_WhenSingleItemOnTheSecondLevel()
        {
            // Arrange
            DimensionStructure secondLevelFirst = new DimensionStructure
            {
                Id = 201,
                Name = "two oh one",
                Desc = "two oh one",
            };
            DimensionStructure secondLevelSecond = new DimensionStructure
            {
                Id = 202,
                Name = "two oh two",
                Desc = "two oh two",
            };
            DimensionStructure firstLevelThird = new DimensionStructure
            {
                Id = 103,
                Name = "one of three",
                Desc = "one oh three",
                ChildDimensionStructures = new List<DimensionStructure>
                {
                    secondLevelFirst,
                    secondLevelSecond
                },
            };
            DimensionStructure firstLevelFirst_secondLevelFirst = new DimensionStructure
            {
                Id = 1201,
                Name = "two oh one",
                Desc = "two oh one",
            };
            DimensionStructure firstLevelFirst_secondLevelSecond = new DimensionStructure
            {
                Id = 1202,
                Name = "two oh two",
                Desc = "two oh two",
            };
            DimensionStructure firstLevelFirst = new DimensionStructure
            {
                Id = 101,
                Name = "one oh one",
                Desc = "one oh one",
                ChildDimensionStructures = new List<DimensionStructure>
                {
                    firstLevelFirst_secondLevelFirst,
                    firstLevelFirst_secondLevelSecond,
                },
            };
            DimensionStructure firstLevelSecond = new DimensionStructure
            {
                Id = 102,
                Name = "two oh two",
                Desc = "two oh two",
            };
            List<DimensionStructure> childDimensionStructures = new List<DimensionStructure>
            {
                firstLevelFirst,
                firstLevelSecond,
                firstLevelThird,
            };
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "root",
                Desc = "root",
                ChildDimensionStructures = childDimensionStructures,
            };
            SourceFormat testData = new SourceFormat
            {
                Id = 100,
                Name = "test",
                Desc = "test desc",
                RootDimensionStructureId = 100,
                RootDimensionStructure = rootDimensionStructure,
            };

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(testData);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync(1202).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();
            builderService.SourceFormat.Id.Should().Be(testData.Id);
            builderService.SourceFormat.Name.Should().Be(testData.Name);
            builderService.SourceFormat.Desc.Should().Be(testData.Desc);

            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);

            // checking first level
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(3);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(p => p.Id == firstLevelFirst.Id).ToList().Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(p => p.Id == firstLevelSecond.Id).ToList().Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(p => p.Id == firstLevelThird.Id).ToList().Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelFirst.Id)
               .ChildDimensionStructures.Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelFirst.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == firstLevelFirst_secondLevelFirst.Id).ToList().Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelThird.Id)
               .ChildDimensionStructures.Count.Should().Be(2);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelThird.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelFirst.Id).ToList().Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelThird.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelSecond.Id).ToList().Count.Should().Be(1);
        }
    }
}
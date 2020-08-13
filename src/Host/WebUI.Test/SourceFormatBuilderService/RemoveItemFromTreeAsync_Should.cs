// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
    public class RemoveItemFromTreeAsync_Should : TestBase
    {
        // [Fact]
        // public async Task Remove_RootDimensionStructure()
        // {
        //     // Arrange
        //     DimensionStructure rootDimensionStructure = new DimensionStructure
        //     {
        //         Id = 100,
        //         Guid = Guid.NewGuid(),
        //         Name = "name",
        //         Desc = "Desc",
        //         ChildDimensionStructures = new List<DimensionStructure>(),
        //     };
        // }

        [Fact(Skip = "tmp")]
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
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);
            builderService.DimensionStructureToBeDeletedFromTree = firstLevelFirst;

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync().ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();
            builderService.SourceFormat.Id.Should().Be(testData.Id);
            builderService.SourceFormat.Name.Should().Be(testData.Name);
            builderService.SourceFormat.Desc.Should().Be(testData.Desc);

            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(1);
            // ReSharper disable once PossibleNullReferenceException
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault().Id.Should().Be(firstLevelSecond.Id);
        }

        [Fact(Skip = "tmp")]
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
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);
            builderService.DimensionStructureToBeDeletedFromTree = firstLevelFirst;

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync().ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();
            builderService.SourceFormat.Id.Should().Be(testData.Id);
            builderService.SourceFormat.Name.Should().Be(testData.Name);
            builderService.SourceFormat.Desc.Should().Be(testData.Desc);

            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(rootDimensionStructure.Id);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(0);
        }

        [Fact(Skip = "tmp")]
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
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);
            builderService.DimensionStructureToBeDeletedFromTree = firstLevelFirst_secondLevelSecond;

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync().ConfigureAwait(false);

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

            // ReSharper disable once PossibleNullReferenceException
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelFirst.Id)
               .ChildDimensionStructures.Count.Should().Be(1);
            // ReSharper disable once PossibleNullReferenceException
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelFirst.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == firstLevelFirst_secondLevelFirst.Id).ToList().Count.Should().Be(1);

            // ReSharper disable once PossibleNullReferenceException
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelThird.Id)
               .ChildDimensionStructures.Count.Should().Be(2);
            // ReSharper disable once PossibleNullReferenceException
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelThird.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelFirst.Id).ToList().Count.Should().Be(1);
            // ReSharper disable once PossibleNullReferenceException
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .FirstOrDefault(p => p.Id == firstLevelThird.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelSecond.Id).ToList().Count.Should().Be(1);
        }

        [Fact(Skip = "tmp")]
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
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);
            builderService.DimensionStructureToBeDeletedFromTree = firstLevelThird;

            // Act
            await builderService.DeleteDocumentStructureFromTreeAsync().ConfigureAwait(false);

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
        public void ThrowException_WhenNoDimensionToBeDeletedSetup()
        {
            // Arrange
            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);
            builderService.DimensionStructureToBeDeletedFromTree = null;

            // Act
            Func<Task> action = async () =>
            {
                await builderService.DeleteDocumentStructureFromTreeAsync()
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
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

    using Microsoft.VisualBasic;

    using Moq;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ReplaceDimensionStructureInTheTreeAsync_Should : TestBase
    {
        [Fact]
        public async Task ReplaceRootDimension()
        {
            // Arrange
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 101,
                Name = "rootdimensionstructure",
                Desc = "rootdimensionstructure description",
            };
            SourceFormat result = new SourceFormat
            {
                Id = 100,
                Name = "sourceformat",
                Desc = "sourceformat description",
                RootDimensionStructureId = 101,
                RootDimensionStructure = rootDimensionStructure,
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(result);
            DimensionStructure newRootDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "new root dimension structure",
                Desc = "new dimension structure desc",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            _masterDataWebApiClientMock
               .Setup(d => d.GetDimensionStructureByIdAsync(It.Is<DimensionStructure>(str => str.Id == 200)))
               .ReturnsAsync(newRootDimensionStructure);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.ReplaceDimensionStructureInTheTree(101, 200).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.RootDimensionStructure.Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructureId.Should().Be(
                newRootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(
                newRootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Name.Should().Be(
                newRootDimensionStructure.Name);
            builderService.SourceFormat.RootDimensionStructure.Desc.Should().Be(
                newRootDimensionStructure.Desc);
        }

        [Fact]
        public async Task ThrowException_WhenDimensionStructureIs_NotInTheTree()
        {
            // Arrange
            DimensionStructure thirdLevelOneOneOne = new DimensionStructure
            {
                Id = 3001,
                Name = "third elvel one one one",
                Desc = "thisd level one one one - desc",
            };
            DimensionStructure thirdLevelOneOneTwo = new DimensionStructure
            {
                Id = 3002,
                Name = "third level one one two",
                Desc = "third level one one two - desc",
            };
            List<DimensionStructure> thirdLevelOneOneOneList = new List<DimensionStructure>
            {
                thirdLevelOneOneOne,
                thirdLevelOneOneTwo,
            };

            DimensionStructure secondLevelOneOne = new DimensionStructure
            {
                Id = 2001,
                Name = "second level one one",
                Desc = "second level one one - desc",
                ChildDimensionStructures = thirdLevelOneOneOneList,
            };
            DimensionStructure secondLevelOneTwo = new DimensionStructure
            {
                Id = 2002,
                Name = "second level one two",
                Desc = "second level one two - desc",
            };
            List<DimensionStructure> secondLevelOneList = new List<DimensionStructure>
            {
                secondLevelOneOne,
                secondLevelOneTwo,
            };

            DimensionStructure firstLevelOneTwo = new DimensionStructure
            {
                Id = 1002,
                Name = "first level one two",
                Desc = "first level one two - desc",
            };
            DimensionStructure firstLevelOneOne = new DimensionStructure
            {
                Id = 1001,
                Name = "first level one one",
                Desc = "first level one one - desc",
                ChildDimensionStructures = secondLevelOneList,
            };
            List<DimensionStructure> firstLevelList = new List<DimensionStructure>
            {
                firstLevelOneOne,
                firstLevelOneTwo,
            };

            DimensionStructure rootDimensionstructure = new DimensionStructure
            {
                Id = 2,
                Name = "Rootdimensionstructure",
                Desc = "desc",
                ChildDimensionStructures = firstLevelList,
            };
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = 1,
                Name = "source format",
                Desc = "source format",
                RootDimensionStructure = rootDimensionstructure,
                RootDimensionStructureId = rootDimensionstructure.Id,
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(sourceFormat);

            DimensionStructure replacedDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "replaced",
                Desc = "replacex - desc",
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetDimensionStructureByIdAsync(It.Is<DimensionStructure>(
                    d => d.Id == 200)))
               .ReturnsAsync(replacedDimensionStructure);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(1).ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await builderService.ReplaceDimensionStructureInTheTree(3003, 200).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<SourceFormatBuilderServiceException>();
        }

        [Fact]
        public async Task ReplaceDimensionStructure_AtFirstLevel()
        {
            // Arrange
            DimensionStructure firstLevelOne = new DimensionStructure
            {
                Id = 1001,
                Name = "first level 1001",
                Desc = "first level 1001 desc",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            DimensionStructure firstLevelSecond = new DimensionStructure
            {
                Id = 1002,
                Name = "first level 1002",
                Desc = "first level 1002",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            List<DimensionStructure> firstLevel = new List<DimensionStructure>
            {
                firstLevelOne,
                firstLevelSecond,
            };
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 101,
                Name = "rootdimensionstructure",
                Desc = "rootdimensionstructure description",
                ChildDimensionStructures = firstLevel,
            };
            SourceFormat result = new SourceFormat
            {
                Id = 100,
                Name = "sourceformat",
                Desc = "sourceformat description",
                RootDimensionStructureId = 101,
                RootDimensionStructure = rootDimensionStructure,
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(result);
            DimensionStructure newRootDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "new root dimension structure",
                Desc = "new dimension structure desc",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            _masterDataWebApiClientMock
               .Setup(d => d.GetDimensionStructureByIdAsync(It.Is<DimensionStructure>(str => str.Id == 200)))
               .ReturnsAsync(newRootDimensionStructure);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.ReplaceDimensionStructureInTheTree(1002, 200).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.RootDimensionStructure.Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructureId.Should().Be(
                rootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(
                rootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Name.Should().Be(
                rootDimensionStructure.Name);
            builderService.SourceFormat.RootDimensionStructure.Desc.Should().Be(
                rootDimensionStructure.Desc);

            builderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(q => q.Id == firstLevelOne.Id)
               .ToList()
               .Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(q => q.Id == firstLevelSecond.Id)
               .ToList()
               .Count.Should().Be(0);

            builderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(q => q.Id == newRootDimensionStructure.Id)
               .ToList()
               .Count.Should().Be(1);
        }

        [Fact]
        public async Task ReplaceDimensionStructure_AtSecondLevel()
        {
            // Arrange
            DimensionStructure secondLevelOneOne = new DimensionStructure
            {
                Id = 2001,
                Name = "second",
                Desc = "second",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            DimensionStructure secondLevelOneTwo = new DimensionStructure
            {
                Id = 2002,
                Name = "second2",
                Desc = "second2",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            List<DimensionStructure> secondLevelOneList = new List<DimensionStructure>
            {
                secondLevelOneOne,
                secondLevelOneTwo
            };
            DimensionStructure secondLevelTwoOne = new DimensionStructure
            {
                Id = 2021,
                Name = "2222second",
                Desc = "second",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            DimensionStructure secondLevelTwoTwo = new DimensionStructure
            {
                Id = 2022,
                Name = "second2",
                Desc = "second2",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            List<DimensionStructure> secondLevelSecondList = new List<DimensionStructure>
            {
                secondLevelTwoOne,
                secondLevelTwoTwo
            };
            DimensionStructure firstLevelOne = new DimensionStructure
            {
                Id = 1001,
                Name = "first level 1001",
                Desc = "first level 1001 desc",
                ChildDimensionStructures = secondLevelOneList,
            };
            DimensionStructure firstLevelSecond = new DimensionStructure
            {
                Id = 1002,
                Name = "first level 1002",
                Desc = "first level 1002",
                ChildDimensionStructures = secondLevelSecondList,
            };
            List<DimensionStructure> firstLevel = new List<DimensionStructure>
            {
                firstLevelOne,
                firstLevelSecond,
            };
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 101,
                Name = "rootdimensionstructure",
                Desc = "rootdimensionstructure description",
                ChildDimensionStructures = firstLevel,
            };
            SourceFormat result = new SourceFormat
            {
                Id = 100,
                Name = "sourceformat",
                Desc = "sourceformat description",
                RootDimensionStructureId = 101,
                RootDimensionStructure = rootDimensionStructure,
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(result);
            DimensionStructure newRootDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "new root dimension structure",
                Desc = "new dimension structure desc",
                ChildDimensionStructures = new List<DimensionStructure>(),
            };
            _masterDataWebApiClientMock
               .Setup(d => d.GetDimensionStructureByIdAsync(It.Is<DimensionStructure>(str => str.Id == 200)))
               .ReturnsAsync(newRootDimensionStructure);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.ReplaceDimensionStructureInTheTree(2002, 200).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.RootDimensionStructure.Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructureId.Should().Be(
                rootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(
                rootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Name.Should().Be(
                rootDimensionStructure.Name);
            builderService.SourceFormat.RootDimensionStructure.Desc.Should().Be(
                rootDimensionStructure.Desc);

            builderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Where(q => q.Id == firstLevelOne.Id)
               .ToList()
               .Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(q => q.Id == firstLevelOne.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelOneOne.Id)
               .ToList()
               .Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .First(q => q.Id == firstLevelOne.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == newRootDimensionStructure.Id)
               .ToList()
               .Count.Should().Be(1);
        }

        [Fact]
        public async Task ReplaceDimensionStructure_AtThirdLevel()
        {
            // Arrange
            DimensionStructure thirdLevelOneOneOne = new DimensionStructure
            {
                Id = 3001,
                Name = "third elvel one one one",
                Desc = "thisd level one one one - desc",
            };
            DimensionStructure thirdLevelOneOneTwo = new DimensionStructure
            {
                Id = 3002,
                Name = "third level one one two",
                Desc = "third level one one two - desc",
            };
            List<DimensionStructure> thirdLevelOneOneOneList = new List<DimensionStructure>
            {
                thirdLevelOneOneOne,
                thirdLevelOneOneTwo,
            };

            DimensionStructure secondLevelOneOne = new DimensionStructure
            {
                Id = 2001,
                Name = "second level one one",
                Desc = "second level one one - desc",
                ChildDimensionStructures = thirdLevelOneOneOneList,
            };
            DimensionStructure secondLevelOneTwo = new DimensionStructure
            {
                Id = 2002,
                Name = "second level one two",
                Desc = "second level one two - desc",
            };
            List<DimensionStructure> secondLevelOneList = new List<DimensionStructure>
            {
                secondLevelOneOne,
                secondLevelOneTwo,
            };

            DimensionStructure firstLevelOneTwo = new DimensionStructure
            {
                Id = 1002,
                Name = "first level one two",
                Desc = "first level one two - desc",
            };
            DimensionStructure firstLevelOneOne = new DimensionStructure
            {
                Id = 1001,
                Name = "first level one one",
                Desc = "first level one one - desc",
                ChildDimensionStructures = secondLevelOneList,
            };
            List<DimensionStructure> firstLevelList = new List<DimensionStructure>
            {
                firstLevelOneOne,
                firstLevelOneTwo,
            };

            DimensionStructure rootDimensionstructure = new DimensionStructure
            {
                Id = 2,
                Name = "Rootdimensionstructure",
                Desc = "desc",
                ChildDimensionStructures = firstLevelList,
            };
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = 1,
                Name = "source format",
                Desc = "source format",
                RootDimensionStructure = rootDimensionstructure,
                RootDimensionStructureId = rootDimensionstructure.Id,
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(sourceFormat);

            DimensionStructure replacedDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "replaced",
                Desc = "replacex - desc",
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetDimensionStructureByIdAsync(It.Is<DimensionStructure>(
                    d => d.Id == 200)))
               .ReturnsAsync(replacedDimensionStructure);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(1).ConfigureAwait(false);

            // Act
            await builderService.ReplaceDimensionStructureInTheTree(3002, 200).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.Should().NotBeNull();

            builderService.SourceFormat.RootDimensionStructure.Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructureId.Should().NotBe(0);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Count.Should().NotBe(0);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Count.Should().Be(firstLevelList.Count);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(q => q.Id == firstLevelOneOne.Id)
               .ToList()
               .Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(q => q.Id == firstLevelOneTwo.Id)
               .ToList()
               .Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .First(q => q.Id == firstLevelOneOne.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelOneOne.Id)
               .ToList()
               .Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .First(q => q.Id == firstLevelOneOne.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == secondLevelOneTwo.Id)
               .ToList()
               .Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .First(q => q.Id == firstLevelOneOne.Id)
               .ChildDimensionStructures
               .First(q => q.Id == secondLevelOneOne.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == thirdLevelOneOneOne.Id)
               .ToList()
               .Count.Should().Be(1);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .First(q => q.Id == firstLevelOneOne.Id)
               .ChildDimensionStructures
               .First(q => q.Id == secondLevelOneOne.Id)
               .ChildDimensionStructures
               .Where(q => q.Id == replacedDimensionStructure.Id)
               .ToList()
               .Count.Should().Be(1);
        }

        [Fact]
        public async Task ReplaceRootDimensionStructure_AndIncludeAllChildDimensionsOfTheAddedOne()
        {
            // Arrange
            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Id = 101,
                Name = "rootdimensionstructure",
                Desc = "rootdimensionstructure description",
            };
            SourceFormat result = new SourceFormat
            {
                Id = 100,
                Name = "sourceformat",
                Desc = "sourceformat description",
                RootDimensionStructureId = 101,
                RootDimensionStructure = rootDimensionStructure,
            };
            _masterDataWebApiClientMock
               .Setup(s => s.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(result);

            DimensionStructure newRoot1 = new DimensionStructure
            {
                Id = 1212,
                Name = "newone 1",
                Desc = "newone 1 desc"
            };
            DimensionStructure newRoot2 = new DimensionStructure
            {
                Id = 2323,
                Name = "newone 2",
                Desc = "newone 2 desc"
            };
            List<DimensionStructure> newRootChildDimensionStructuresList = new List<DimensionStructure>
            {
                newRoot1, newRoot2
            };
            DimensionStructure newRootDimensionStructure = new DimensionStructure
            {
                Id = 200,
                Name = "new root dimension structure",
                Desc = "new dimension structure desc",
                ChildDimensionStructures = newRootChildDimensionStructuresList,
            };
            _masterDataWebApiClientMock
               .Setup(d => d.GetDimensionStructureByIdAsync(It.Is<DimensionStructure>(str => str.Id == 200)))
               .ReturnsAsync(newRootDimensionStructure);

            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);
            await builderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await builderService.ReplaceDimensionStructureInTheTree(101, 200).ConfigureAwait(false);

            // Assert
            builderService.SourceFormat.RootDimensionStructure.Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructureId.Should().Be(
                newRootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Id.Should().Be(
                newRootDimensionStructure.Id);
            builderService.SourceFormat.RootDimensionStructure.Name.Should().Be(
                newRootDimensionStructure.Name);
            builderService.SourceFormat.RootDimensionStructure.Desc.Should().Be(
                newRootDimensionStructure.Desc);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures.Should().NotBeNull();
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Count.Should().Be(newRootChildDimensionStructuresList.Count);

            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(q => q.Id == newRoot1.Id)
               .ToList()
               .Count.Should().Be(1);
            builderService.SourceFormat.RootDimensionStructure.ChildDimensionStructures
               .Where(q => q.Id == newRoot2.Id)
               .ToList()
               .Count.Should().Be(1);
        }
    }
}
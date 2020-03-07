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
        }
    }
}
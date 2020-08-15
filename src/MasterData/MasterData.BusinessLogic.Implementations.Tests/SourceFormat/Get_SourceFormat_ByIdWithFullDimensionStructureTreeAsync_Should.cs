// <copyright file="Get_SourceFormat_ByIdWithFullDimensionStructureTreeAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class Get_SourceFormat_ByIdWithFullDimensionStructureTreeAsync_Should : TestBase
    {
        public Get_SourceFormat_ByIdWithFullDimensionStructureTreeAsync_Should()
            : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Get_SourceFormat_ByIdWithFullDimensionStructureTreeAsync_Should);

        [Fact]
        public async Task Return_SourceFormat_WithRootDimensionStructure()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "source format",
                Desc = "Source format",
                IsActive = 1,
            };
            SourceFormat sourceFormatResult = await masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);

            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Name = "root",
                Desc = "root",
                IsActive = 1,
            };
            DimensionStructure rootDimensionStructureResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                rootDimensionStructure).ConfigureAwait(false);
            sourceFormatResult.RootDimensionStructureId = rootDimensionStructureResult.Id;
            SourceFormat updatedSourceFormatResult = await masterDataBusinessLogic.UpdateSourceFormatAsync(
                sourceFormatResult).ConfigureAwait(false);

            // Act
            SourceFormat result = await masterDataBusinessLogic.GetSourceFormatByIdWithFullDimensionStructureTreeAsync(
                updatedSourceFormatResult).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sourceFormatResult.Id);
            result.Name.Should().Be(sourceFormatResult.Name);
            result.Desc.Should().Be(sourceFormatResult.Desc);
            result.RootDimensionStructureId.Should().Be(sourceFormatResult.RootDimensionStructureId);
        }

        [Fact]
        public async Task Return_SourceFormat_WithTree_WithOneLevelDepth()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "source format",
                Desc = "Source format",
                IsActive = 1,
            };
            SourceFormat sourceFormatResult = await masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);

            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Name = "root",
                Desc = "root",
                IsActive = 1,
            };
            DimensionStructure rootDimensionStructureResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                rootDimensionStructure).ConfigureAwait(false);
            sourceFormatResult.RootDimensionStructureId = rootDimensionStructureResult.Id;
            SourceFormat updatedSourceFormatResult = await masterDataBusinessLogic.UpdateSourceFormatAsync(
                sourceFormatResult).ConfigureAwait(false);

            // Adding first level dimension structures to the root
            DimensionStructure dimensionStructureFirstLevelOne = new DimensionStructure
            {
                Name = "First level one",
                Desc = "First level one",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelOneResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelOne).ConfigureAwait(false);

            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOne =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = rootDimensionStructureResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                };
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneResult =
                await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOne)
                   .ConfigureAwait(false);

            DimensionStructure dimensionStructureFirstLevelTwo = new DimensionStructure
            {
                Name = "First Level second",
                Desc = "first level second",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelTwoResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelTwo)
               .ConfigureAwait(false);
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecond =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = rootDimensionStructureResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelTwoResult.Id,
                };
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecondResult =
                await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelSecond)
                   .ConfigureAwait(false);

            // Act
            SourceFormat result = await masterDataBusinessLogic.GetSourceFormatByIdWithFullDimensionStructureTreeAsync(
                    sourceFormatResult)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sourceFormatResult.Id);
            result.Name.Should().Be(sourceFormatResult.Name);
            result.Desc.Should().Be(sourceFormatResult.Desc);
            result.RootDimensionStructureId.Should().Be(sourceFormatResult.RootDimensionStructureId);
            result.RootDimensionStructure.ChildDimensionStructures.Should().NotBeNull();
            result.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(2);
        }

        [Fact]
        public async Task Return_SourceFormat_WithTree_WithTwoLevelDepth()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "source format",
                Desc = "Source format",
                IsActive = 1,
            };
            SourceFormat sourceFormatResult = await masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);

            DimensionStructure rootDimensionStructure = new DimensionStructure
            {
                Name = "root",
                Desc = "root",
                IsActive = 1,
            };
            DimensionStructure rootDimensionStructureResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                rootDimensionStructure).ConfigureAwait(false);
            sourceFormatResult.RootDimensionStructureId = rootDimensionStructureResult.Id;
            SourceFormat updatedSourceFormatResult = await masterDataBusinessLogic.UpdateSourceFormatAsync(
                sourceFormatResult).ConfigureAwait(false);

            // Adding first level dimension structures to the root
            DimensionStructure dimensionStructureFirstLevelOne = new DimensionStructure
            {
                Name = "First level one",
                Desc = "First level one",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelOneResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelOne).ConfigureAwait(false);

            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOne =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = rootDimensionStructureResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                };
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneResult =
                await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOne)
                   .ConfigureAwait(false);

            DimensionStructure dimensionStructureFirstLevelSecond = new DimensionStructure
            {
                Name = "First Level second",
                Desc = "first level second",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelSecondResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelSecond)
               .ConfigureAwait(false);
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecond =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = rootDimensionStructureResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelSecondResult.Id,
                };
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecondResult =
                await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelSecond)
                   .ConfigureAwait(false);

            // Adding Second levels to First Level one
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelOne = new DimensionStructure
            {
                Name = "first level one - Second Level One",
                Desc = "first level one - Second Level one",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelOneResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelOneSecondLevelOne)
               .ConfigureAwait(false);
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneSecondLevelOne =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelOneSecondLevelOneResult.Id,
                };
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneSecondLevelOneResult =
                await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOneSecondLevelOne)
                   .ConfigureAwait(false);

            DimensionStructure dimensionStructureFirstLevelOneSecondLevelSecond = new DimensionStructure
            {
                Name = "first level one - second level second",
                Desc = "first level one - second level second",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelSecondResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelOneSecondLevelSecond)
               .ConfigureAwait(false);

            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneSecondLevelSecond =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelOneSecondLevelSecondResult.Id,
                };
            DimensionStructureDimensionStructure
                dimensionStructureDimensionStructureFirstLevelOneSecondLevelSecondResult =
                    await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                            dimensionStructureDimensionStructureFirstLevelOneSecondLevelSecond)
                       .ConfigureAwait(false);

            // Adding Second Levels to First Level second
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelOne = new DimensionStructure
            {
                Name = "first level second - Second Level One",
                Desc = "first level second - Second Level one",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelOneResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelSecondSecondLevelOne)
               .ConfigureAwait(false);
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecondSecondLevelOne =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = dimensionStructureFirstLevelSecondResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelSecondSecondLevelOneResult.Id,
                };
            DimensionStructureDimensionStructure
                dimensionStructureDimensionStructureFirstLevelSecondSecondLevelOneResult =
                    await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                            dimensionStructureDimensionStructureFirstLevelSecondSecondLevelOne)
                       .ConfigureAwait(false);

            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelSecond = new DimensionStructure
            {
                Name = "first level second - second level second",
                Desc = "first level second - second level second",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelSecondResult = await masterDataBusinessLogic
               .AddDimensionStructureAsync(dimensionStructureFirstLevelSecondSecondLevelSecond)
               .ConfigureAwait(false);

            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecondSecondLevelSecond =
                new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = dimensionStructureFirstLevelSecondResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelSecondSecondLevelSecondResult.Id,
                };
            DimensionStructureDimensionStructure
                dimensionStructureDimensionStructureFirstLevelSecondSecondLevelSecondResult =
                    await masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                            dimensionStructureDimensionStructureFirstLevelSecondSecondLevelSecond)
                       .ConfigureAwait(false);

            // Act
            SourceFormat result = await masterDataBusinessLogic.GetSourceFormatByIdWithFullDimensionStructureTreeAsync(
                    sourceFormatResult)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sourceFormatResult.Id);
            result.Name.Should().Be(sourceFormatResult.Name);
            result.Desc.Should().Be(sourceFormatResult.Desc);
            result.RootDimensionStructureId.Should().Be(sourceFormatResult.RootDimensionStructureId);
            result.RootDimensionStructure.ChildDimensionStructures.Should().NotBeNull();
            result.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(2);

            //first level
            result.RootDimensionStructure.ChildDimensionStructures.Where(
                    p => p.Name == dimensionStructureFirstLevelOne.Name)
               .ToList()
               .Count
               .Should().Be(1);
            result.RootDimensionStructure.ChildDimensionStructures.Where(
                    p => p.Name == dimensionStructureFirstLevelSecond.Name)
               .ToList()
               .Count
               .Should().Be(1);

            // second levels
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelOne.Name)
               .ChildDimensionStructures.Should().NotBeNull();
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelOne.Name)
               .ChildDimensionStructures.Count
               .Should().Be(2);
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelOne.Name)
               .ChildDimensionStructures
               .Count
               .Should().Be(2);
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelOne.Name)
               .ChildDimensionStructures
               .Where(n => n.Name == dimensionStructureFirstLevelOneSecondLevelOne.Name)
               .ToList()
               .Count
               .Should().Be(1);
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelOne.Name)
               .ChildDimensionStructures
               .Where(n => n.Name == dimensionStructureFirstLevelOneSecondLevelSecond.Name)
               .ToList()
               .Count
               .Should().Be(1);

            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelSecond.Name)
               .ChildDimensionStructures.Should().NotBeNull();
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelSecond.Name)
               .ChildDimensionStructures.Count
               .Should().Be(2);
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelSecond.Name)
               .ChildDimensionStructures
               .Where(n => n.Name == dimensionStructureFirstLevelSecondSecondLevelSecond.Name)
               .ToList()
               .Count
               .Should().Be(1);
            result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
                    p => p.Name == dimensionStructureFirstLevelSecond.Name)
               .ChildDimensionStructures
               .Where(n => n.Name == dimensionStructureFirstLevelSecondSecondLevelSecond.Name)
               .ToList()
               .Count
               .Should().Be(1);
        }
    }
}
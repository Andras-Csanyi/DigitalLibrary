// <copyright file="Get_SourceFormat_ByIdWithFullDimensionStructureTreeAsync_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    public partial class SourceFormatFeature
    {
        [Scenario]
        public async Task Return_SourceFormat_WithRootDimensionStructure()
        {
            // Arrange
            SourceFormat sourceFormat = null;
            SourceFormat sourceFormatResult = null;
            DimensionStructure rootDimensionStructure = null;
            DimensionStructure rootDimensionStructureResult = null;
            SourceFormat updatedSourceFormatResult = null;
            SourceFormat result = null;

            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "source format",
                    Desc = "Source format",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => sourceFormatResult = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            "And there is a Dimension Structure"
               .x(() => rootDimensionStructure = new DimensionStructure
                {
                    Name = "root",
                    Desc = "root",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => rootDimensionStructureResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                    rootDimensionStructure).ConfigureAwait(false));

            "And DimensionStructure is root dimension structure of source format"
               .x(() => sourceFormatResult.RootDimensionStructureId = rootDimensionStructureResult.Id);

            "And Source format is updated"
               .x(async () => updatedSourceFormatResult = await _masterDataBusinessLogic.UpdateSourceFormatAsync(
                    sourceFormatResult).ConfigureAwait(false));

            "When source format is queried by id"
               .x(async () => result = await _masterDataBusinessLogic
                   .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(
                        updatedSourceFormatResult).ConfigureAwait(false));

            "Then result should not be null".x(() => result.Should().NotBeNull());
            "And result id should be equal to original source format id"
               .x(() => result.Id.Should().Be(sourceFormatResult.Id));
            "And result name should be equal to original source format name"
               .x(() => result.Name.Should().Be(sourceFormatResult.Name));
            "And result desc should be equal to original source format desc"
               .x(() => result.Desc.Should().Be(sourceFormatResult.Desc));
            "And result root dimension structure id should be equal to original source format root dimension structure id"
               .x(() => result.RootDimensionStructureId.Should().Be(sourceFormatResult.RootDimensionStructureId));
            "And result has a root dimension structure"
               .x(() => result.RootDimensionStructure.Should().NotBeNull());
        }

        [Scenario]
        public async Task Return_SourceFormat_WithTree_WithOneLevelDepth()
        {
            // Arrange
            SourceFormat sourceFormat = null;
            SourceFormat sourceFormatResult = null;
            DimensionStructure rootDimensionStructure = null;
            DimensionStructure rootDimensionStructureResult = null;
            DimensionStructure dimensionStructureFirstLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelOneResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelTwo = null;
            DimensionStructure dimensionStructureFirstLevelTwoResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecond = null;
            SourceFormat result = null;

            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "source format",
                    Desc = "Source format",
                    IsActive = 1,
                });
            "And it is stored in the database"
               .x(async () => sourceFormatResult = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            "And there is a dimension structure"
               .x(() => rootDimensionStructure = new DimensionStructure
                {
                    Name = "root",
                    Desc = "root",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => rootDimensionStructureResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                    rootDimensionStructure).ConfigureAwait(false));

            "And dimension structure is marked as root dimension structure"
               .x(() => sourceFormatResult.RootDimensionStructureId = rootDimensionStructureResult.Id);

            "And source format is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.UpdateSourceFormatAsync(
                    sourceFormatResult).ConfigureAwait(false));

            // Adding first level dimension structures to the root
            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelOne = new DimensionStructure
                {
                    Name = "First level one",
                    Desc = "First level one",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => dimensionStructureFirstLevelOneResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelOne).ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelOne = new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = rootDimensionStructureResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                });

            "And the dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOne)
                   .ConfigureAwait(false));

            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelTwo = new DimensionStructure
                {
                    Name = "First Level second",
                    Desc = "first level second",
                    IsActive = 1,
                });

            "And it is added to the database"
               .x(async () => dimensionStructureFirstLevelTwoResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelTwo)
                   .ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelSecond =
                    new DimensionStructureDimensionStructure
                    {
                        DimensionStructureId = rootDimensionStructureResult.Id,
                        ChildDimensionStructureId = dimensionStructureFirstLevelTwoResult.Id,
                    });

            "And dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelSecond)
                   .ConfigureAwait(false));

            "When I query the source format by id"
               .x(async () => result = await _masterDataBusinessLogic
                   .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(
                        sourceFormatResult)
                   .ConfigureAwait(false));

            "Then the result is not null".x(() => result.Should().NotBeNull());
            "And result id should be equal to original source format id"
               .x(() => result.Id.Should().Be(sourceFormatResult.Id));
            "And result name should be equal to original source format name"
               .x(() => result.Name.Should().Be(sourceFormatResult.Name));
            "And result desc should be equal to original source format desc"
               .x(() => result.Desc.Should().Be(sourceFormatResult.Desc));
            "And result root dimension structure id should be equal to original source format root dimension structure id"
               .x(() => result.RootDimensionStructureId.Should().Be(sourceFormatResult.RootDimensionStructureId));
            "And result's rootdimensionstructure should have more than one child"
               .x(() => result.RootDimensionStructure.ChildDimensionStructures.Should().NotBeNull());
            "And result's rootdimensionstructe should have given amount of child item"
               .x(() => result.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(2));
        }

        [Scenario]
        public async Task Return_SourceFormat_WithTree_WithTwoLevelDepth()
        {
            // Arrange
            SourceFormat sourceFormat = null;
            SourceFormat sourceFormatResult = null;
            DimensionStructure rootDimensionStructure = null;
            DimensionStructure rootDimensionStructureResult = null;
            DimensionStructure dimensionStructureFirstLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelOneResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelTwo = null;
            DimensionStructure dimensionStructureFirstLevelTwoResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecond = null;
            SourceFormat result = null;
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelOneResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneSecondLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelSecond = null;
            DimensionStructure dimensionStructureFirstLevelOneSecondLevelSecondResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelOneSecondLevelSecond =
                null;
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelOne = null;
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelOneResult = null;
            DimensionStructureDimensionStructure dimensionStructureDimensionStructureFirstLevelSecondSecondLevelOne =
                null;
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelSecond = null;
            DimensionStructure dimensionStructureFirstLevelSecondSecondLevelSecondResult = null;
            DimensionStructureDimensionStructure
                dimensionStructureDimensionStructureFirstLevelSecondSecondLevelSecond = null;

            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "source format",
                    Desc = "Source format",
                    IsActive = 1,
                });
            "And it is stored in the database"
               .x(async () => sourceFormatResult = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            "And there is a dimension structure"
               .x(() => rootDimensionStructure = new DimensionStructure
                {
                    Name = "root",
                    Desc = "root",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => rootDimensionStructureResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                    rootDimensionStructure).ConfigureAwait(false));

            "And dimension structure is marked as root dimension structure"
               .x(() => sourceFormatResult.RootDimensionStructureId = rootDimensionStructureResult.Id);

            "And source format is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.UpdateSourceFormatAsync(
                    sourceFormatResult).ConfigureAwait(false));

            // Adding first level dimension structures to the root
            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelOne = new DimensionStructure
                {
                    Name = "First level one",
                    Desc = "First level one",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => dimensionStructureFirstLevelOneResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelOne).ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelOne = new DimensionStructureDimensionStructure
                {
                    DimensionStructureId = rootDimensionStructureResult.Id,
                    ChildDimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                });

            "And the dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOne)
                   .ConfigureAwait(false));

            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelTwo = new DimensionStructure
                {
                    Name = "First Level second",
                    Desc = "first level second",
                    IsActive = 1,
                });

            "And it is added to the database"
               .x(async () => dimensionStructureFirstLevelTwoResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelTwo)
                   .ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelSecond =
                    new DimensionStructureDimensionStructure
                    {
                        DimensionStructureId = rootDimensionStructureResult.Id,
                        ChildDimensionStructureId = dimensionStructureFirstLevelTwoResult.Id,
                    });

            "And dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelSecond)
                   .ConfigureAwait(false));

            // Adding Second levels to First Level one
            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelOneSecondLevelOne = new DimensionStructure
                {
                    Name = "first level one - Second Level One",
                    Desc = "first level one - Second Level one",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => dimensionStructureFirstLevelOneSecondLevelOneResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelOneSecondLevelOne)
                   .ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelOneSecondLevelOne =
                    new DimensionStructureDimensionStructure
                    {
                        DimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                        ChildDimensionStructureId = dimensionStructureFirstLevelOneSecondLevelOneResult.Id,
                    });
            "And dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOneSecondLevelOne)
                   .ConfigureAwait(false));

            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelOneSecondLevelSecond = new DimensionStructure
                {
                    Name = "first level one - second level second",
                    Desc = "first level one - second level second",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => dimensionStructureFirstLevelOneSecondLevelSecondResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelOneSecondLevelSecond)
                   .ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelOneSecondLevelSecond =
                    new DimensionStructureDimensionStructure
                    {
                        DimensionStructureId = dimensionStructureFirstLevelOneResult.Id,
                        ChildDimensionStructureId = dimensionStructureFirstLevelOneSecondLevelSecondResult.Id,
                    });

            "And the dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelOneSecondLevelSecond)
                   .ConfigureAwait(false));

            // Adding Second Levels to First Level second
            "And there is a dimension structure "
               .x(() => dimensionStructureFirstLevelSecondSecondLevelOne = new DimensionStructure
                {
                    Name = "first level second - Second Level One",
                    Desc = "first level second - Second Level one",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => dimensionStructureFirstLevelSecondSecondLevelOneResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelSecondSecondLevelOne)
                   .ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelSecondSecondLevelOne =
                    new DimensionStructureDimensionStructure
                    {
                        DimensionStructureId = dimensionStructureFirstLevelTwoResult.Id,
                        ChildDimensionStructureId = dimensionStructureFirstLevelSecondSecondLevelOneResult.Id,
                    });

            "And dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelSecondSecondLevelOne)
                   .ConfigureAwait(false));

            "And there is a dimension structure"
               .x(() => dimensionStructureFirstLevelSecondSecondLevelSecond = new DimensionStructure
                {
                    Name = "first level second - second level second",
                    Desc = "first level second - second level second",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => dimensionStructureFirstLevelSecondSecondLevelSecondResult = await _masterDataBusinessLogic
                   .AddDimensionStructureAsync(dimensionStructureFirstLevelSecondSecondLevelSecond)
                   .ConfigureAwait(false));

            "And it is marked as part of the dimension structure tree"
               .x(() => dimensionStructureDimensionStructureFirstLevelSecondSecondLevelSecond =
                    new DimensionStructureDimensionStructure
                    {
                        DimensionStructureId = dimensionStructureFirstLevelTwoResult.Id,
                        ChildDimensionStructureId = dimensionStructureFirstLevelSecondSecondLevelSecondResult.Id,
                    });

            "And dimension structure tree is updated accordingly"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureDimensionStructureAsync(
                        dimensionStructureDimensionStructureFirstLevelSecondSecondLevelSecond)
                   .ConfigureAwait(false));

            "When I query the source format by id"
               .x(async () => result = await _masterDataBusinessLogic
                   .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(
                        sourceFormatResult)
                   .ConfigureAwait(false));

            "Then the result is not null".x(() => result.Should().NotBeNull());
            "And result id should be equal to original source format id"
               .x(() => result.Id.Should().Be(sourceFormatResult.Id));
            "And result name should be equal to original source format name"
               .x(() => result.Name.Should().Be(sourceFormatResult.Name));
            "And result desc should be equal to original source format desc"
               .x(() => result.Desc.Should().Be(sourceFormatResult.Desc));
            "And result root dimension structure id should be equal to original source format root dimension structure id"
               .x(() => result.RootDimensionStructureId.Should().Be(sourceFormatResult.RootDimensionStructureId));
            "And result's rootdimensionstructure should have more than one child"
               .x(() => result.RootDimensionStructure.ChildDimensionStructures.Should().NotBeNull());
            "And result's rootdimensionstructe should have given amount of child item"
               .x(() => result.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(2));


            //first level
            "And first level should have given amount of dimension structures"
               .x(() => result.RootDimensionStructure.ChildDimensionStructures.Where(
                        p => p.Name == dimensionStructureFirstLevelOne.Name)
                   .ToList()
                   .Count
                   .Should().Be(1));

            "And first level should have given amount of dimension structures"
               .x(() => result.RootDimensionStructure.ChildDimensionStructures.Where(
                        p => p.Name == dimensionStructureFirstLevelTwo.Name)
                   .ToList()
                   .Count
                   .Should().Be(1));

            // second levels
            // "And first level dimension structure should have children dimension structures"
            //    .x(() => result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //             p => p.Name == dimensionStructureFirstLevelOne.Name)
            //        .ChildDimensionStructures.Should().NotBeNull());
            //
            // "And first level dimension structure should have given amont of child dimension structure"
            //    .x(() => result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //             p => p.Name == dimensionStructureFirstLevelOne.Name)
            //        .ChildDimensionStructures.Count
            //        .Should().Be(2));
            //
            // "And first level dimension structure should have given amont of child dimension structure"
            //    .x(() => result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //             p => p.Name == dimensionStructureFirstLevelTwo.Name)
            //        .ChildDimensionStructures
            //        .Count
            //        .Should().Be(2));
            //
            // "And given node should have given amount of children"
            //    .x(() => result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //             p => p.Name == dimensionStructureFirstLevelOne.Name)
            //        .ChildDimensionStructures
            //        .Where(n => n.Name == dimensionStructureFirstLevelOneSecondLevelOne.Name)
            //        .ToList()
            //        .Count
            //        .Should().Be(1));
            //
            // "And given node should have given amount of children"
            //    .x(() => result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //             p => p.Name == dimensionStructureFirstLevelTwo.Name)
            //        .ChildDimensionStructures
            //        .Where(n => n.Name == dimensionStructureFirstLevelOneSecondLevelSecond.Name)
            //        .ToList()
            //        .Count
            //        .Should().Be(1));
            //
            // result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //         p => p.Name == dimensionStructureFirstLevelSecond.Name)
            //    .ChildDimensionStructures.Should().NotBeNull();
            // result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //         p => p.Name == dimensionStructureFirstLevelSecond.Name)
            //    .ChildDimensionStructures.Count
            //    .Should().Be(2);
            // result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //         p => p.Name == dimensionStructureFirstLevelSecond.Name)
            //    .ChildDimensionStructures
            //    .Where(n => n.Name == dimensionStructureFirstLevelSecondSecondLevelSecond.Name)
            //    .ToList()
            //    .Count
            //    .Should().Be(1);
            // result.RootDimensionStructure.ChildDimensionStructures.FirstOrDefault(
            //         p => p.Name == dimensionStructureFirstLevelSecond.Name)
            //    .ChildDimensionStructures
            //    .Where(n => n.Name == dimensionStructureFirstLevelSecondSecondLevelSecond.Name)
            //    .ToList()
            //    .Count
            //    .Should().Be(1);
        }
    }
}
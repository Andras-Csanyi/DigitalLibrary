// <copyright file="SourceFormatFeature.AddAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering AddAsync method.
    /// </summary>
    public partial class SourceFormatFeature
    {
        [Scenario]
        public void AddAsync_AddsWhenSourceFormatDoesntHaveRootDimensionStructure()
        {
            SourceFormat sourceFormat = null;
            SourceFormat result = null;

            "Given there is a new SourceFormat without DimensionStructure tree."
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });

            "When adding SourceFormat"
               .x(async () => result = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            "Then the result should not be null"
               .x(() => result.Should().NotBeNull());
            "And result.id should be greater than 0"
               .x(() => result.Id.Should().BeGreaterThan(0));
            "And result.name should be equal to the new source format's name"
               .x(() => result.Name.Should().Be(sourceFormat.Name));
            "And result.Desc should be equal to the new source format's description"
               .x(() => result.Desc.Should().Be(sourceFormat.Desc));
            "And result.IsActive should be equal to the new source format's is active value"
               .x(() => result.IsActive.Should().Be(sourceFormat.IsActive));
        }

        [Scenario]
        public void AddAsync_AddsWhenSourceFormatHasNewRootDimensionButNoDimensionTree()
        {
            SourceFormat sourceFormat = null;
            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "source format",
                    Desc = "desc",
                    IsActive = 1,
                });

            DimensionStructure dimensionStructure = null;
            "And there is a dimension structure"
               .x(() => dimensionStructure = new DimensionStructure
                {
                    Name = "dim struct",
                    Desc = "desc",
                    IsActive = 1,
                });

            "And dimension structure is root dimension structure of source format"
               .x(() => { sourceFormat.RootDimensionStructure = dimensionStructure; });

            SourceFormat result = null;
            "When source format is saved it returns with the saved source format"
               .x(async () => result = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            "Then result is not null"
               .x(() => result.Should().NotBeNull());
            "And result source format id is not 0"
               .x(() => result.Id.Should().NotBe(0));
            "And result source format name equals to original's name"
               .x(() => result.Name.Should().Be(sourceFormat.Name));
            "And result source format desc equals to original's desc"
               .x(() => result.Desc.Should().Be(sourceFormat.Desc));
            "And result source format is active equals to original's is active"
               .x(() => result.IsActive.Should().Be(sourceFormat.IsActive));
            "And result source format root dimension is not null"
               .x(() => result.RootDimensionStructure.Should().NotBeNull());
            "And result source format root dimension id is not 0"
               .x(() => result.RootDimensionStructureId.Should().NotBe(0));
            "And root dimension name equals to original's name"
               .x(() => result.RootDimensionStructure.Name.Should().Be(dimensionStructure.Name));
            "And root dimension desc equals to original's desc"
               .x(() => result.RootDimensionStructure.Desc.Should().Be(dimensionStructure.Desc));
            "And root dimension is active equals to original's is active"
               .x(() => result.RootDimensionStructure.IsActive.Should().Be(dimensionStructure.IsActive));
        }

        [Scenario]
        public void AddAsync_AddsWhenSourceFormatHasAlreadyExistingDimensionStructureAsRootDimensionStructure()
        {
            SourceFormat sourceFormat = null;
            "Given there is a source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "source format",
                    Desc = "desc",
                    IsActive = 1,
                });

            DimensionStructure dimensionStructure = null;
            "And there is a dimension structure"
               .x(() => dimensionStructure = new DimensionStructure
                {
                    Name = "dimension structure name",
                    Desc = "desc",
                    IsActive = 1,
                });

            DimensionStructure dimensionStructureResult = null;
            "And dimension structure is saved in the database"
               .x(async () => dimensionStructureResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                        dimensionStructure)
                   .ConfigureAwait(false));

            "And dimension structure is root dimension structure of source format"
               .x(() =>
               {
                  sourceFormat.RootDimensionStructure = dimensionStructureResult;
                  sourceFormat.RootDimensionStructureId = dimensionStructureResult.Id;
               });

            SourceFormat result = null;
            "When source format is saved it returns with the saved source format"
               .x(async () => result = await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false));

            "Then result is not null"
               .x(() => result.Should().NotBeNull());
            "And result source format id is not 0"
               .x(() => result.Id.Should().NotBe(0));
            "And result source format name equals to original's name"
               .x(() => result.Name.Should().Be(sourceFormat.Name));
            "And result source format desc equals to original's desc"
               .x(() => result.Desc.Should().Be(sourceFormat.Desc));
            "And result source format is active equals to original's is active"
               .x(() => result.IsActive.Should().Be(sourceFormat.IsActive));
            "And result source format root dimension is not null"
               .x(() => result.RootDimensionStructure.Should().NotBeNull());
            "And result source format root dimension structure's id equals to dimension structure id"
               .x(() => result.RootDimensionStructure.Id.Should().Be(dimensionStructureResult.Id));
            "And result source format root dimension id is not 0"
               .x(() => result.RootDimensionStructureId.Should().NotBe(0));
            "And result source format root dimension id equals to root dimension structure id"
               .x(() => result.RootDimensionStructureId.Should().Be(dimensionStructureResult.Id));
            "And root dimension name equals to original's name"
               .x(() => result.RootDimensionStructure.Name.Should().Be(dimensionStructure.Name));
            "And root dimension name equals to original saved one's name"
               .x(() => result.RootDimensionStructure.Name.Should().Be(dimensionStructureResult.Name));
            "And root dimension desc equals to original's desc"
               .x(() => result.RootDimensionStructure.Desc.Should().Be(dimensionStructure.Desc));
            "And root dimension desc equals to original saved one's desc"
               .x(() => result.RootDimensionStructure.Desc.Should().Be(dimensionStructureResult.Desc));
            "And root dimension is active equals to original's is active"
               .x(() => result.RootDimensionStructure.IsActive.Should().Be(dimensionStructure.IsActive));
            "And root dimension is active equals to original saved one's is active"
               .x(() => result.RootDimensionStructure.IsActive.Should().Be(dimensionStructureResult.IsActive));
        }

        [Fact] // done
        public void AddAsync_AddsWithOneLevelMultipleDimensionStructureTreeDimensionStructuresAreExist()
        {
        }

        [Fact]
        public void AddAsync_AddsWithOneLevelMultipleDimensionStructureTreeDimensionStructuresAreNew()
        {
        }

        [Fact]
        public void AddAsync_AddsWithOneLevelSingleDimensionStructureTreeDimensionStructuresAreNew()
        {
        }

        [Fact]
        public void AddAsync_AddsWithOneLevelSingleDimensionStructureTreeDimensionStructuresExist()
        {
        }

        [Fact]
        public void AddAsync_AddsWithoutCreatingDimensionStructureWhenRootDimensionIsAlreadyAttachedToOtherEntities()
        {
        }

        [Fact]
        public void AddAsync_AddsWithThreeLevelMultipleDimensionStructureTreeDimensionStructuresAreExist()
        {
        }

        [Fact]
        public void AddAsync_AddsWithThreeLevelMultipleDimensionStructureTreeDimensionStructuresAreNew()
        {
        }

        [Fact]
        public void AddAsync_AddsWithThreeLevelSingleDimensionStructureTreeDimensionStructuresAreExist()
        {
        }

        [Fact]
        public void AddAsync_AddsWithThreeLevelSingleDimensionStructureTreeDimensionStructuresAreNew()
        {
        }

        [Fact]
        public void AddAsync_AddsWithTwoLevelMultipleDimensionStructureTreeDimensionStructuresAreExist()
        {
        }

        [Fact]
        public void AddAsync_AddsWithTwoLevelMultipleDimensionStructureTreeDimensionStructuresAreNew()
        {
        }

        [Fact]
        public void AddAsync_AddsWithTwoLevelSingleDimensionStructureTreeDimensionStructuresAreExist()
        {
        }

        [Fact]
        public void AddAsync_AddsWithTwoLevelSingleDimensionStructureTreeDimensionStructuresAreNew()
        {
        }

        [Scenario]
        public void AddAsync_ThrowsExpectionWhenNameUniqueConstraintIsViolated()
        {
            SourceFormat sourceFormat = null;
            Func<Task> action = null;

            "Given there is a new source format"
               .x(() => sourceFormat = new SourceFormat
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });

            "And the source format is already present in the database"
               .x(async () => await _masterDataBusinessLogic.AddSourceFormatAsync(
                        sourceFormat)
                   .ConfigureAwait(false));

            "When I try to add it again, so I violate the unique constraint of entities in the database"
               .x(() =>
                {
                    action = async () =>
                    {
                        await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat).ConfigureAwait(false);
                    };
                });

            "Then the business logic should throw MasterDataBusinessLogicAddSourceFormatAsyncOperationException"
               .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicAddSourceFormatAsyncOperationException>());
        }
    }
}
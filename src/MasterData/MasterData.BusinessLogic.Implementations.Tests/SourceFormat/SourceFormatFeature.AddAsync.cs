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
               .x(async () => result = await _masterDataBusinessLogic.AddSourceFormatAsync(
                    sourceFormat).ConfigureAwait(false));

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

        [Fact]
        public void AddAsync_AddsWhenSourceFormatHasRootDimensionButNoDimensionTree()
        {
        }

        [Fact]
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
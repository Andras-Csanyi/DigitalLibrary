// <copyright file="Add_SourceFormat_Should.cs" company="Andras Csanyi">
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

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public partial class SourceFormatFeature
    {
        [Scenario]
        public void Add_WhenSourceFormat_DoesntHaveRootDimensionStructure()
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
        public async Task Add_WhenSourceFormatHasRootDimension_ButNoDimensionTree()
        {
        }

        [Fact]
        public async Task Add_WithOneLevelMultiple_DimensionStructureTree_DimensionStructuresAreExist()
        {
        }

        [Fact]
        public async Task Add_WithOneLevelMultiple_DimensionStructureTree_DimensionStructuresAreNew()
        {
        }

        [Fact]
        public async Task Add_WithOneLevelSingle_DimensionStructureTree_DimensionStructuresAreNew()
        {
        }

        [Fact]
        public async Task Add_WithOneLevelSingle_DimensionStructureTree_DimensionStructuresExist()
        {
        }

        [Fact]
        public async Task Add_WithoutCreatingDimensionStructure_WhenRootDimension_IsAlreadyAttached_ToOtherEntities()
        {
        }

        [Fact]
        public async Task Add_WithThreeLevelMultiple_DimensionStructureTree_DimensionStructuresAreExist()
        {
        }

        [Fact]
        public async Task Add_WithThreeLevelMultiple_DimensionStructureTree_DimensionStructuresAreNew()
        {
        }

        [Fact]
        public async Task Add_WithThreeLevelSingle_DimensionStructureTree_DimensionStructuresAreExist()
        {
        }

        [Fact]
        public async Task Add_WithThreeLevelSingle_DimensionStructureTree_DimensionStructuresAreNew()
        {
        }

        [Fact]
        public async Task Add_WithTwoLevelMultiple_DimensionStructureTree_DimensionStructuresAreExist()
        {
        }

        [Fact]
        public async Task Add_WithTwoLevelMultiple_DimensionStructureTree_DimensionStructuresAreNew()
        {
        }

        [Fact]
        public async Task Add_WithTwoLevelSingle_DimensionStructureTree_DimensionStructuresAreExist()
        {
        }

        [Fact]
        public async Task Add_WithTwoLevelSingle_DimensionStructureTree_DimensionStructuresAreNew()
        {
        }

        [Scenario]
        public async Task Add_ThrowExpection_WhenNameUniqueConstraintIsViolated()
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
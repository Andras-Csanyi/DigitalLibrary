// <copyright file="DimensionStructureFeature.GetDimensionStructureByIdAsync.WithChildren.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering GetDimensionStructureByIdAsync_WithChildren functionality.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        [Scenario]
        public void GetDimensionStructureByIdAsync_ReturnsChildrenWhenItIsNotRootDimensionStructure()
        {
            DimensionStructure dimensionStructureForId = null;
            "Given a dimension structure is queried from database"
               .x(async () => dimensionStructureForId = await _masterDataBusinessLogic
                   .GetDimensionStructureByNameAsync(
                        MasterDataDataSample.HungarianBusinessPartnerAddressName)
                   .ConfigureAwait(false));

            DimensionStructureQueryObject dimensionStructureQueryObject = null;
            "And there is a query"
               .x(() => dimensionStructureQueryObject = new DimensionStructureQueryObject
                {
                    GetDimensionsStructuredById = dimensionStructureForId.Id,
                    IncludeChildrenWhenGetDimensionStructureById = true,
                });

            DimensionStructure result = null;
            "When dimension structure is queried"
               .x(async () => result = await _masterDataBusinessLogic
                   .GetDimensionStructureByIdAsync(dimensionStructureQueryObject)
                   .ConfigureAwait(false));

            "Then childrenstructure should not be empty or null"
               .x(() => result.ChildDimensionStructures.Should().NotBeNullOrEmpty());
            "And childrenstructures length should be 3"
               .x(() => result.ChildDimensionStructures.Count.Should().Be(3));
        }

        [Scenario]
        public async Task GetDimensionStructureByIdAsync_ReturnsChildrenWhenItIsRootDimension()
        {
            DimensionStructure dimensionStructureForId = null;
            "Given there is a dimension structure with children in the database"
               .x(async () => dimensionStructureForId = await _masterDataBusinessLogic
                   .GetDimensionStructureByNameAsync(
                        MasterDataDataSample.HungarianBusinessPartnerRootDimensionStructureName)
                   .ConfigureAwait(false));

            DimensionStructureQueryObject dimensionStructureQueryObject = null;
            "And there is a query for getting it with dimension structure tree"
               .x(() => dimensionStructureQueryObject = new DimensionStructureQueryObject
                {
                    GetDimensionsStructuredById = dimensionStructureForId.Id,
                    IncludeChildrenWhenGetDimensionStructureById = true,
                });

            DimensionStructure result = null;
            "When dimension structure is queried with its dimension structure tree by id"
               .x(async () => result = await _masterDataBusinessLogic
                   .GetDimensionStructureByIdAsync(dimensionStructureQueryObject)
                   .ConfigureAwait(false));

            "Then child dimension structures is not null".x(() =>
                result.ChildDimensionStructures.Should().NotBeNullOrEmpty());
            "And amount of child dimension structures is 4"
               .x(() => result.ChildDimensionStructures.Count.Should().Be(4));
        }
    }
}
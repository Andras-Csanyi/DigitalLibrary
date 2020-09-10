// <copyright file="Get_DimensionStructure_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Tests covering Get functionality.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        [Scenario(Skip = "Needs to be reviewed.")]
        public async Task Get_AnItem()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                    dimensionStructure)
               .ConfigureAwait(false);

            DimensionStructure dimensionStructure2 = new DimensionStructure
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 0,
            };
            DimensionStructure dimensionStructure2Result = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                    dimensionStructure2)
               .ConfigureAwait(false);

            // Act
            List<DimensionStructure> result = await _masterDataBusinessLogic.GetDimensionStructuresAsync()
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
            result.Where(p => p.Name == dimensionStructure.Name).ToList().Count.Should().Be(1);
            result.Where(p => p.Name == dimensionStructure2.Name).ToList().Count.Should().Be(1);
        }
    }
}
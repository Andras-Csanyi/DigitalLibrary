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
        [Scenario]
        public async Task Get_AnItem()
        {
            DimensionStructure dimensionStructure = null;
            "Given there is a dimension structure"
               .x(() => dimensionStructure = new DimensionStructure
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureAsync(
                        dimensionStructure)
                   .ConfigureAwait(false));

            DimensionStructure dimensionStructure2 = null;
            "And there is a dimension structure"
               .x(() => dimensionStructure2 = new DimensionStructure
                {
                    Name = "name2",
                    Desc = "desc2",
                    IsActive = 0,
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureAsync(
                        dimensionStructure2)
                   .ConfigureAwait(false));

            List<DimensionStructure> result = null;
            "When dimension structures list is queried"
               .x(async () => result = await _masterDataBusinessLogic.GetDimensionStructuresAsync()
                   .ConfigureAwait(false));

            "Then result list is not null".x(() => result.Should().NotBeNull());
            "And result list length is more than 0".x(() => result.Count.Should().BeGreaterThan(0));
            "And first dimension structure is in the list"
               .x(() => result.Where(p => p.Name == dimensionStructure.Name).ToList().Count.Should().Be(1));
            "And second dimension structure is in the list"
               .x(() => result.Where(p => p.Name == dimensionStructure2.Name).ToList().Count.Should().Be(1));
        }
    }
}
// <copyright file="Delete_DimensionStructure_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering Delete functionality.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        [Scenario]
        public async Task DeleteAnItem()
        {
            List<DimensionStructure> initList = null;
            "Given we know the amount of dimension structures in the database"
               .x(async () => initList = await _masterDataBusinessLogic.GetDimensionStructuresAsync()
                   .ConfigureAwait(false));

            DimensionStructure dimensionStructure = null;
            "And there is a dimension structure"
               .x(() => dimensionStructure = new DimensionStructure
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });

            "And dimension structure is saved in the database"
               .x(async () => await _masterDataBusinessLogic.AddDimensionStructureAsync(
                        dimensionStructure)
                   .ConfigureAwait(false));

            DimensionStructure dimensionStructure2 = null;
            "And there is a dimension structure"
               .x(() => dimensionStructure2 = new DimensionStructure
                {
                    Name = "name2",
                    Desc = "desc2",
                    IsActive = 1,
                });

            DimensionStructure dimensionStructure2Result = null;
            "And dimension structure is stored in the database"
               .x(async () => dimensionStructure2Result = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                        dimensionStructure2)
                   .ConfigureAwait(false));


            "When the latter dimension structure is deleted from the database"
               .x(async () => await _masterDataBusinessLogic.DeleteDimensionStructureAsync(dimensionStructure2Result)
                   .ConfigureAwait(false));

            List<DimensionStructure> result = null;
            "And the result list is queried"
               .x(async () => result = await _masterDataBusinessLogic.GetDimensionStructuresAsync()
                   .ConfigureAwait(false));

            "Then result count is initlist count +1 ".x(() => result.Count.Should().Be(initList.Count + 1));
            "And the first dimension structure is in the list"
               .x(() => result.Where(p => p.Name == dimensionStructure.Name).ToList().Count.Should().Be(1));
            "And the second, deleted, dimension structure is not in the list"
               .x(() => result.Where(p => p.Name == dimensionStructure2.Name).ToList().Count.Should().Be(0));
        }

        [Scenario]
        public void DeleteThrowsExceptionWhenThereIsNoSuchDimensionStructure()
        {
            DimensionStructure dimensionStructure = null;
            "Given there is a dimension structure points to not existing data in database"
               .x(() => dimensionStructure = new DimensionStructure
                {
                    Id = 1000,
                });

            Func<Task> action = null;
            "When not existing dimension structure is deleted"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.DeleteDimensionStructureAsync(dimensionStructure)
                       .ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }
    }
}
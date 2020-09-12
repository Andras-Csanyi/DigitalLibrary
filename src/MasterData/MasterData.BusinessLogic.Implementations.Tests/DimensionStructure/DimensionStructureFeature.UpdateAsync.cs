// <copyright file="DimensionStructureFeature.UpdateAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering Update functionality.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        [Scenario]
        public void UpdateAsync_ThrowsWhenThereIsNoSuchEntity()
        {
            DimensionStructure orig = null;
            "Given there is a dimensions structure"
               .x(() => orig = new DimensionStructure
                {
                    Id = 100,
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });

            Func<Task> action = null;
            "When a dimension structure is update which is not in the database"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.UpdateDimensionStructureAsync(orig).ConfigureAwait(false);
                });

            "Then an exception thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }

        [Scenario]
        public async Task UpdateAsync_UpdatesDimensionStructure()
        {
            // Arrange
            string updateName = "update name";
            string updateDesc = "update desc";
            int updateIsActive = 0;

            DimensionStructure orig = null;
            "Given there is a dimension structure"
               .x(() => orig = new DimensionStructure
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                });
            DimensionStructure origResult = null;
            "And it is stored in the database"
               .x(async () => origResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(orig)
                   .ConfigureAwait(false));

            "And dimension structure properties are updated"
               .x(() =>
                {
                    origResult.Name = updateName;
                    origResult.Desc = updateDesc;
                    origResult.IsActive = updateIsActive;
                });

            DimensionStructure updatedResult = null;
            "When modified dimension structure is saved"
               .x(async () => updatedResult = await _masterDataBusinessLogic.UpdateDimensionStructureAsync(origResult)
                   .ConfigureAwait(false));

            "Then the returning result's id should be the same as it was"
               .x(() => updatedResult.Id.Should().Be(origResult.Id));
            "And returning result's name equals to modified name"
               .x(() => updatedResult.Name.Should().Be(updateName));
            "And returning result's desc equals to modified desc"
               .x(() => updatedResult.Desc.Should().Be(updateDesc));
            "And returning result's is active equals to modified is active"
               .x(() => updatedResult.IsActive.Should().Be(updateIsActive));
        }
    }
}
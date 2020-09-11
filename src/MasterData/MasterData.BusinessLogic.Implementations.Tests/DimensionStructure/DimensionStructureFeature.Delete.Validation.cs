// <copyright file="Delete_DimensionStructure_Validation_Should.cs" company="Andras Csanyi">
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
    /// Test cases covering Delete functionality validation.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        [Scenario]
        public void DeleteThrowsExceptionWhenInputIsNull()
        {
            Func<Task> action = null;
            "When delete dimension structure method is call with a null input"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.DeleteDimensionStructureAsync(null)
                       .ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException>()
                   .WithInnerException<GuardException>());
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
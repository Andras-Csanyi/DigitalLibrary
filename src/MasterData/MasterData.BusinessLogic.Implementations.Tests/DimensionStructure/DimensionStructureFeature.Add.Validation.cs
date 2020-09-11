// <copyright file="Add_DimensionStructure_Validation_Should.cs" company="Andras Csanyi">
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
    using DigitalLibrary.MasterData.Validators.TestData;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using FluentValidation;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering Add functionality validation.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        [Scenario]
        [MemberData(
            nameof(MasterData_DimensionStructure_Validation_TestData.AddDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_Validation_TestData))]
        public void ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            DimensionStructure dimensionStructure = null;
            "Given there is a dimension structure with invalid data"
               .x(() => dimensionStructure = new DimensionStructure
                {
                    Id = id,
                    Name = name,
                    Desc = desc,
                    IsActive = isActive,
                });

            Func<Task> action = null;
            "When the dimension with invalid data gets saved"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.AddDimensionStructureAsync(dimensionStructure)
                       .ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicAddDimensionStructureAsyncOperationException>()
                   .WithInnerException<ValidationException>());
        }

        [Scenario]
        public void ThrowException_WhenInputIsNull()
        {
            Func<Task> action = null;
            "When the save dimension structure is called with null input"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.AddDimensionStructureAsync(null).ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicAddDimensionStructureAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }
    }
}
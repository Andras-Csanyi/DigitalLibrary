// <copyright file="Update_DimensionValue_Validation_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
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
    /// Tests covering Update validation.
    /// </summary>
    public partial class DimensionValueFeature
    {
        [Scenario]
        [MemberData(
            nameof(MasterData_DimensionValue_TestData.DimensionValue_Modify_TestData),
            MemberType = typeof(MasterData_DimensionValue_TestData))]
        public void ThrowException_WhenInputIsNull(
            long id,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionValue)
        {
            Func<Task> action = null;
            "When updating with invalid values"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                        id,
                        oldDimensionValue,
                        newDimensionValue).ConfigureAwait(false);
                });

            "Then it throws exception"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                   .WithInnerExceptionExactly<GuardException>());
        }

        [Scenario]
        public void ThrowException_WhenOldDimensionValue_HasZeroId()
        {
            DimensionValue old = null;
            "Given there is the old dimension value with zero id"
               .x(() => old = new DimensionValue());

            DimensionValue nw = new DimensionValue();
            "And there is the new dimension value with zero id"
               .x(() => nw = new DimensionValue());

            Func<Task> action = null;
            "When the dimension value is updated"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                        100,
                        old,
                        nw).ConfigureAwait(false);
                });

            "Then it throws exception"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                   .WithInnerException<ValidationException>());
        }
    }
}
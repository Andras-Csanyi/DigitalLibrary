// <copyright file="Update_DimensionStructure_Validation_Should.cs" company="Andras Csanyi">
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

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test cases covering Update functionality validation.
    /// </summary>
    public partial class DimensionStructureFeature
    {
        // [Scenario(Skip = "Needs to be reviewed.")]
        // [MemberData(
        //     nameof(MasterData_DimensionStructure_Validation_TestData.ModifyDimensionStructure_Validation_TestData),
        //     MemberType = typeof(MasterData_DimensionStructure_TestData))]
        // public void Update_Validation_ThrowException_WhenInputIsInvalid(
        //     long id,
        //     string name,
        //     string desc,
        //     int isActive)
        // {
        //     // Arrange
        //     DimensionStructure dimensionStructure = new DimensionStructure
        //     {
        //         Id = id,
        //         Name = name,
        //         Desc = desc,
        //         IsActive = isActive,
        //     };
        //
        //     // Act
        //     Func<Task> action = async () =>
        //     {
        //         await _masterDataBusinessLogic.UpdateDimensionStructureAsync(dimensionStructure)
        //            .ConfigureAwait(false);
        //     };
        //
        //     // Assert
        //     action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException>();
        // }

        [Scenario(Skip = "Needs to be reviewed.")]
        public void Update_Validation_ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.UpdateDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}
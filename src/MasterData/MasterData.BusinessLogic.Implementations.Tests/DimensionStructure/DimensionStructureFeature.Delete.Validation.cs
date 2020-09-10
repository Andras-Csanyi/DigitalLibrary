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
        [Scenario(Skip = "Needs to be reviewed.")]
        public void Delete_ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.DeleteDimensionStructureAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException>()
               .WithInnerException<GuardException>();
        }

        [Scenario(Skip = "Needs to be reviewed.")]
        public void Delete_ThrowException_WhenThereIsNoSuchDimensionStructure()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = 1000,
            };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.DeleteDimensionStructureAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}
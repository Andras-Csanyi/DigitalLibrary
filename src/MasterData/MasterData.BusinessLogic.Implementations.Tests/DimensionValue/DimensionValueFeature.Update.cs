// <copyright file="Update_DimensionValue_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System;
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
    /// Test cases covering update functionality.
    /// </summary>
    public partial class DimensionValueFeature
    {
        [Scenario(Skip = "not implemented yet")]
        public void CreateANewDimensionValueForDimension_IfTheModifiedDimensionValueHasMultipleConnections()
        {
        }

        [Scenario(Skip = "Has to be reviewed.")]
        public async Task ModifyDimensionValue_WhenTheModifiedValueHasASingleDimensionRelation()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1,
            };
            Dimension dimensionResult = await _masterDataBusinessLogic
               .AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            DimensionValue dimVal1 = new DimensionValue
            {
                Value = "dimval1",
            };
            DimensionValue dimVal1Result = await _masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal1,
                dimensionResult.Id).ConfigureAwait(false);

            // Act
            DimensionValue dimval1Modified = new DimensionValue
            {
                Value = "super-duper value",
            };
            DimensionValue result = await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                dimensionResult.Id,
                dimVal1Result,
                dimval1Modified).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimVal1Result.Id);
            result.Value.Should().Be(dimval1Modified.Value);

            Dimension dimCheck = await _masterDataBusinessLogic
               .GetValuesOfADimensionAsync(dimensionResult.Id)
               .ConfigureAwait(false);
            dimCheck.DimensionDimensionValues.Count.Should().Be(1);
            dimCheck.DimensionDimensionValues.ElementAt(0).DimensionValueId.Should().Be(dimVal1Result.Id);
            dimCheck.DimensionDimensionValues.ElementAt(0).DimensionValue.Value
               .Should().Be(dimval1Modified.Value);

            long count = await _masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);
            count.Should().Be(1);
        }

        [Scenario(Skip = "Has to be reviewed.")]
        public void Update_ThrowException_WhenThereIsNoSuchDimension()
        {
            // Arrange
            DimensionValue oldDimensionValue = new DimensionValue
            {
                Id = 101,
                Value = "asd",
            };

            DimensionValue newDimensionValue = new DimensionValue
            {
                Value = "asdasd",
            };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.ModifyDimensionValueAsync(100, oldDimensionValue, newDimensionValue)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
               .WithInnerException<GuardException>();
        }

        [Scenario(Skip = "Has to be reviewed.")]
        public async Task ThrowException_WhenThereIsNoSuchDimensionDimensionValueRelation()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1,
            };
            Dimension dimensionResult = await _masterDataBusinessLogic
               .AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            DimensionValue dimVal1 = new DimensionValue
            {
                Value = "dimval1",
            };
            DimensionValue dimVal1Result = await _masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal1,
                dimensionResult.Id).ConfigureAwait(false);

            DimensionValue dimVal2 = new DimensionValue
            {
                Value = "dimval2",
            };
            DimensionValue dimVal2Result = await _masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal2,
                dimensionResult.Id).ConfigureAwait(false);

            Dimension dimension2 = new Dimension
            {
                Name = "dimension 2",
                Description = "desc",
                IsActive = 1,
            };
            Dimension dimension2Result = await _masterDataBusinessLogic
               .AddDimensionAsync(dimension2)
               .ConfigureAwait(false);
            DimensionValue dimVal3 = new DimensionValue
            {
                Value = "dimval3",
            };
            DimensionValue dimVal3Result = await _masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal3,
                dimension2Result.Id).ConfigureAwait(false);

            // Act
            DimensionValue dimVal3Modification = new DimensionValue
            {
                Value = "modified value",
            };
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                    dimension.Id,
                    dimVal3Result,
                    dimVal3Modification).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity>();
        }

        [Scenario(Skip = "Has to be reviewed.")]
        public async Task ThrowException_WhenThereIsNoSuchValue()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1,
            };
            Dimension dimensionResult = await _masterDataBusinessLogic
               .AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            DimensionValue oldDimensionValue = new DimensionValue
            {
                Id = 101,
                Value = "old one",
            };

            DimensionValue modifiedOldOne = new DimensionValue
            {
                Value = "modified stuff",
            };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                        dimension.Id,
                        oldDimensionValue,
                        modifiedOldOne)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}
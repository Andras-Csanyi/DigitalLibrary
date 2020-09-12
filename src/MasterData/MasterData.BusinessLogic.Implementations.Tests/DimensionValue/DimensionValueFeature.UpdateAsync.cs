// <copyright file="DimensionValueFeature.UpdateAsync.cs" company="Andras Csanyi">
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
        public void UpdateAsync_CreatesANewDimensionValueForDimensionIfTheModifiedDimensionValueHasMultipleConnections()
        {
        }

        [Scenario]
        public void UpdateAsync_UpdatesDimensionValueWhenTheModifiedValueHasASingleDimensionRelation()
        {
            Dimension dimension = null;
            "Given there is a dimension"
               .x(() => dimension = new Dimension
                {
                    Name = "name",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimensionResult = null;
            "And it is saved on the database"
               .x(async () => dimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension)
                   .ConfigureAwait(false));

            DimensionValue dimVal1 = null;
            "And there is a dimension value"
               .x(() => dimVal1 = new DimensionValue
                {
                    Value = "dimval1",
                });

            DimensionValue dimVal1Result = null;
            "and it is added to the dimension"
               .x(async () => dimVal1Result = await _masterDataBusinessLogic.AddDimensionValueAsync(
                        dimVal1,
                        dimensionResult.Id)
                   .ConfigureAwait(false));

            DimensionValue dimval1Modified = null;
            "And the first dimension value is modified"
               .x(() => dimval1Modified = new DimensionValue
                {
                    Value = "super-duper value",
                });

            DimensionValue result = null;
            "When modified dimension value is saved"
               .x(async () => result = await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                        dimensionResult.Id,
                        dimVal1Result,
                        dimval1Modified)
                   .ConfigureAwait(false));

            "Then the returning value is not null".x(() => result.Should().NotBeNull());
            "And the returning value id equals to dimension value i"
               .x(() => result.Id.Should().Be(dimVal1Result.Id));
            "And the returning value equals to modified value"
               .x(() => result.Value.Should().Be(dimval1Modified.Value));

            Dimension dimCheck = null;
            "And dimension values"
               .x(async () => dimCheck = await _masterDataBusinessLogic
                   .GetValuesOfADimensionAsync(dimensionResult.Id)
                   .ConfigureAwait(false));
            "And dimension dimension values relations amount is 1"
               .x(() => dimCheck.DimensionDimensionValues.Count.Should().Be(1));
            "And dimension dimensiond values single element's id equals to dimension value"
               .x(() => dimCheck.DimensionDimensionValues.ElementAt(0).DimensionValueId
                   .Should().Be(dimVal1Result.Id));
            "And dimension dimension values single element's value equals to dimension value"
               .x(() => dimCheck.DimensionDimensionValues.ElementAt(0).DimensionValue.Value
                   .Should().Be(dimval1Modified.Value));

            "And amount of dimension value of the dimension value is 1"
               .x(async () =>
                {
                    long count = await _masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);
                    count.Should().Be(1);
                });
        }

        [Scenario]
        public void UpdateAsync_ThrowsWhenThereIsNoSuchDimension()
        {
            DimensionValue oldDimensionValue = null;
            "Given there is already stored dimension value"
               .x(() => oldDimensionValue = new DimensionValue
                {
                    Id = 101,
                    Value = "asd",
                });

            DimensionValue newDimensionValue = null;
            "And there is a new dimension value"
               .x(() => newDimensionValue = new DimensionValue
                {
                    Value = "asdasd",
                });

            Func<Task> action = null;
            "When non existing dimension id is provided for update"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.ModifyDimensionValueAsync(100, oldDimensionValue, newDimensionValue)
                       .ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }

        [Scenario]
        public void UpdateAsync_ThrowsWhenThereIsNoSuchDimensionDimensionValueRelation()
        {
            Dimension dimension = null;
            "Given there is the first dimension"
               .x(() => dimension = new Dimension
                {
                    Name = "name",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimensionResult = null;
            "And it is stored in the database"
               .x(async () => dimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension)
                   .ConfigureAwait(false));

            DimensionValue dimVal1 = null;
            "And there is the first dimension value"
               .x(() => dimVal1 = new DimensionValue
                {
                    Value = "dimval1",
                });

            "And first dimension value is stored and attached to first dimension"
               .x(async () => await _masterDataBusinessLogic.AddDimensionValueAsync(dimVal1, dimensionResult.Id)
                   .ConfigureAwait(false));

            DimensionValue dimVal2 = null;
            "And there is the second dimension value"
               .x(() => dimVal2 = new DimensionValue
                {
                    Value = "dimval2",
                });

            "And it is stored and attached to first dimension"
               .x(async () => await _masterDataBusinessLogic.AddDimensionValueAsync(dimVal2, dimensionResult.Id)
                   .ConfigureAwait(false));

            Dimension dimension2 = null;
            "And there is the second dimension"
               .x(() => dimension2 = new Dimension
                {
                    Name = "dimension 2",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimension2Result = null;
            "And the second dimension is stored in the database"
               .x(async () => dimension2Result = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension2)
                   .ConfigureAwait(false));

            DimensionValue dimVal3 = null;
            "And there is a third dimension value"
               .x(() => dimVal3 = new DimensionValue
                {
                    Value = "dimval3",
                });

            DimensionValue dimVal3Result = null;
            "And the third dimension value is stored and attached to the second dimension"
               .x(async () => dimVal3Result = await _masterDataBusinessLogic.AddDimensionValueAsync(
                    dimVal3,
                    dimension2Result.Id).ConfigureAwait(false));

            DimensionValue dimVal3Modification = null;
            "And there is a value modification for the third dimension value"
               .x(() => dimVal3Modification = new DimensionValue
                {
                    Value = "modified value",
                });

            Func<Task> action = null;
            "When the modification for the third dimension value is saved for the first dimension"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                        dimension.Id,
                        dimVal3Result,
                        dimVal3Modification).ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                   .WithInnerException<MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity>());
        }

        [Scenario]
        public void UpdateAsync_ThrowsWhenThereIsNoSuchValue()
        {
            Dimension dimension = null;
            "Given there is the first dimension"
               .x(() => dimension = new Dimension
                {
                    Name = "name",
                    Description = "desc",
                    IsActive = 1,
                });

            "And first dimension is stored in the database"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension)
                   .ConfigureAwait(false));

            DimensionValue oldDimensionValue = null;
            "And there is the old dimension value"
               .x(() => oldDimensionValue = new DimensionValue
                {
                    Id = 101,
                    Value = "old one",
                });

            DimensionValue modifiedOldOne = null;
            "And there is the new dimension value"
               .x(() => modifiedOldOne = new DimensionValue
                {
                    Value = "modified stuff",
                });

            Func<Task> action = null;
            "When modification is saved for dimension value but dimension doesn't have such value"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.ModifyDimensionValueAsync(
                            dimension.Id,
                            oldDimensionValue,
                            modifiedOldOne)
                       .ConfigureAwait(false);
                });

            "Then an exception is thrown"
               .x(() => action.Should()
                   .ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                   .WithInnerException<GuardException>());
        }
    }
}
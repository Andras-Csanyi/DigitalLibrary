// <copyright file="Add_DimensionValue_Should.cs" company="Andras Csanyi">
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
    /// Tests covering adding <see cref="DimensionValue"/> operations.
    /// </summary>
    public partial class DimensionValueFeature
    {
        [Scenario]
        public void AddSecondValueToDimensionValueOfASingleDimension()
        {
            Dimension dimension = null;
            "Given is a dimension"
               .x(() => dimension = new Dimension
                {
                    Name = "name",
                    Description = "Desc",
                    IsActive = 1,
                });

            Dimension dimensionResult = null;
            "And it is stored in the database"
               .x(async () => dimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension)
                   .ConfigureAwait(false));

            DimensionValue firstDimensionValue = null;
            "And there is a dimension value"
               .x(() => firstDimensionValue = new DimensionValue
                {
                    Value = "first value",
                });

            DimensionValue firstDimensionValueResult = null;
            "And it is added to the dimension"
               .x(async () => firstDimensionValueResult = await _masterDataBusinessLogic
                   .AddDimensionValueAsync(firstDimensionValue, dimensionResult.Id)
                   .ConfigureAwait(false));

            DimensionValue secondDimensionValue = null;
            "And there is another dimension value"
               .x(() => secondDimensionValue = new DimensionValue
                {
                    Value = "second value",
                });

            DimensionValue secondDimensionValueResult = null;
            "When the second dimension value is added to the same dimension"
               .x(async () => secondDimensionValueResult = await _masterDataBusinessLogic
                   .AddDimensionValueAsync(secondDimensionValue, dimensionResult.Id)
                   .ConfigureAwait(false));

            Dimension res = null;
            "Then the dimension is saved"
               .x(async () => res = await _masterDataBusinessLogic
                   .GetValuesOfADimensionAsync(dimensionResult.Id)
                   .ConfigureAwait(false));

            "And it is not null".x(() => res.Should().NotBeNull());
            "And dimension name hasn't change".x(() => res.Name.Should().Be(dimension.Name));
            "And dimension description hasn't changed".x(() => res.Description.Should().Be(dimension.Description));
            "And dimension has 2 values".x(() => res.DimensionDimensionValues.Count.Should().Be(2));


            "And one of the dimension values is the original one"
               .x(() =>
                {
                    DimensionDimensionValue res1 = res.DimensionDimensionValues.FirstOrDefault(
                        p => p.DimensionId == dimensionResult.Id
                          && p.DimensionValueId == firstDimensionValueResult.Id);
                    res1.Should().NotBeNull();
                });

            "And the other value is also there"
               .x(() =>
                {
                    DimensionDimensionValue res2 = res.DimensionDimensionValues.FirstOrDefault(
                        p => p.DimensionId == dimensionResult.Id
                          && p.DimensionValueId == secondDimensionValueResult.Id);
                    res2.Should().NotBeNull();
                });
        }

        [Scenario]
        public void Create_AddDimensionValueAndConnectToDimension()
        {
            Dimension alreadyExistingDimension = null;
            "Given there is a dimension"
               .x(() => alreadyExistingDimension = new Dimension
                {
                    Name = "name",
                    Description = "Description",
                    IsActive = 1,
                });

            Dimension alreadyExistingDimensionResult = null;
            "And it is stored in the database"
               .x(async () => alreadyExistingDimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(alreadyExistingDimension)
                   .ConfigureAwait(false));

            DimensionValue secondDimensionValue = null;
            "And there is a new value"
               .x(() => secondDimensionValue = new DimensionValue
                {
                    Value = "value",
                });

            DimensionValue secondDimensionValueResult = null;
            "When the new value is added to the dimension"
               .x(async () => secondDimensionValueResult = await _masterDataBusinessLogic
                   .AddDimensionValueAsync(secondDimensionValue, alreadyExistingDimensionResult.Id)
                   .ConfigureAwait(false));

            "Then dimension value is saved".x(() => secondDimensionValueResult.Should().NotBeNull());
            "And its id is not zero".x(() => secondDimensionValueResult.Id.Should().NotBe(0));
            "And its value is also saved"
               .x(() => secondDimensionValueResult.Value.Should().Be(secondDimensionValue.Value));
            "And dimension value is attached"
               .x(() => secondDimensionValueResult.DimensionDimensionValues.Count.Should().Be(1));
        }

        [Scenario]
        public async Task Create_DimensionValueDimensionRelation_WhenDimensionValueExist_ButNoDimensionRelation()
        {
            // Arrange
            Dimension alreadyExistingDimension = null;
            "Given there is a dimension"
               .x(() => alreadyExistingDimension = new Dimension
                {
                    Name = "name",
                    Description = "Description",
                    IsActive = 1,
                });

            Dimension alreadyExistingDimensionResult = null;
            "And it is added to the database"
               .x(async () => alreadyExistingDimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(alreadyExistingDimension)
                   .ConfigureAwait(false));

            Dimension secondDimension = null;
            "And there is a dimension"
               .x(() => secondDimension = new Dimension
                {
                    Name = "Second dimension",
                    Description = "Second dimension description",
                    IsActive = 1,
                });

            Dimension secondDimensionResult = null;
            "And it is recorded in the database"
               .x(async () => secondDimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(secondDimension)
                   .ConfigureAwait(false));

            DimensionValue alreadyExistingDimensionValue = null;
            "And there is a dimension value"
               .x(() => alreadyExistingDimensionValue = new DimensionValue
                {
                    Value = "value",
                });
            "And it is added to the already existing dimension"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(alreadyExistingDimensionValue, alreadyExistingDimensionResult.Id)
                   .ConfigureAwait(false));

            DimensionValue secondDimensionValue = null;
            "And there is a dimension value"
               .x(() => secondDimensionValue = new DimensionValue
                {
                    Value = "value",
                });

            DimensionValue secondDimensionValueResult = null;
            "When the second dimension value is added to the same dimension"
               .x(async () => secondDimensionValueResult = await _masterDataBusinessLogic
                   .AddDimensionValueAsync(secondDimensionValue, secondDimensionResult.Id)
                   .ConfigureAwait(false));

            "Then the result type is expected"
               .x(() => secondDimensionValueResult.Should().BeOfType<DimensionValue>());
            "And the result id is not zero".x(() => secondDimensionValueResult.Id.Should().NotBe(0));
            "And the value is the expected"
               .x(() => secondDimensionValueResult.Value.Should().Be(secondDimensionValue.Value));
            "And the dimension values count is the expected"
               .x(() => secondDimensionValueResult.DimensionDimensionValues.Count.Should().Be(1));
            "And dimension values list has the second dimension value"
               .x(() => secondDimensionValueResult
                   .DimensionDimensionValues.FirstOrDefault(p => p.DimensionId == secondDimensionResult.Id)
                   .Should()
                   .NotBeNull());
        }

        [Scenario]
        public async Task Return_DimensionValue_WithRelatedEntities_WhenDimensionValueAndDimensionRelationAlreadyExist()
        {
            // Arrange
            Dimension alreadyExistingDimension = null;
            "Given there is a dimension"
               .x(() => alreadyExistingDimension = new Dimension
                {
                    Name = "name",
                    Description = "Description",
                    IsActive = 1,
                });
            Dimension alreadyExistingDimensionResult = null;
            "And it is stored in the database"
               .x(async () => alreadyExistingDimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(alreadyExistingDimension)
                   .ConfigureAwait(false));

            DimensionValue alreadyExistingDimensionValue = null;
            "And there is a dimension value"
               .x(() => alreadyExistingDimensionValue = new DimensionValue
                {
                    Value = "value",
                });

            DimensionValue alreadyExistingDimensionValueResult = null;
            "And dimension value is added to the dimension"
               .x(async () => alreadyExistingDimensionValueResult = await _masterDataBusinessLogic
                   .AddDimensionValueAsync(alreadyExistingDimensionValue, alreadyExistingDimensionResult.Id)
                   .ConfigureAwait(false));

            DimensionValue secondDimensionValue = null;
            "And there is a dimension value"
               .x(() => secondDimensionValue = new DimensionValue
                {
                    Value = "value",
                });

            DimensionValue secondDimensionValueResult = null;
            "When second dimension value is added to dimension"
               .x(async () => secondDimensionValueResult = await _masterDataBusinessLogic
                   .AddDimensionValueAsync(secondDimensionValue, alreadyExistingDimensionResult.Id)
                   .ConfigureAwait(false));

            // Assert
            "Then result is not null".x(() => secondDimensionValueResult.Should().NotBeNull());
            "And result id is equal to dimension id"
               .x(() => secondDimensionValueResult.Id.Should().Be(alreadyExistingDimensionValueResult.Id));
            "And result value is equal to value"
               .x(() => secondDimensionValueResult.Value.Should().Be(alreadyExistingDimensionValueResult.Value));
            "And dimension value result value count is equals to 1"
               .x(() => secondDimensionValueResult.DimensionDimensionValues.Count.Should().Be(1));
        }

        [Scenario]
        public void ThrowException_WhenThereIsNoSuchDimension()
        {
            long dimensionId = 0;
            "Given there is a dimension id"
               .x(() => dimensionId = 100);

            DimensionValue dimensionValue = null;
            "And there is a dimension value"
               .x(() => dimensionValue = new DimensionValue
                {
                    Value = "something string",
                });

            Func<Task> action = null;
            "When dimension value is added to dimension doesn't exist"
               .x(() => action = async () =>
                {
                    await _masterDataBusinessLogic.AddDimensionValueAsync(dimensionValue, dimensionId)
                       .ConfigureAwait(false);
                });

            "Then it throws exception"
               .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionValueAsyncOperationException>()
                   .WithInnerExceptionExactly<GuardException>());
        }
    }
}
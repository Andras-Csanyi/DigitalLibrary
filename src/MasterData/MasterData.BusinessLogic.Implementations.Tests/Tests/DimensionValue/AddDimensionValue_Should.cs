using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.DomainModel.DomainModel;

using FluentAssertions;

using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionValue
{
    using Exceptions;

    [ExcludeFromCodeCoverage]
    public class AddDimensionValue_Should : TestBase
    {
        public AddDimensionValue_Should() : base("bla22")
        {
        }

        private const string TestInfo = nameof(AddDimensionValue_Should);

        [Fact]
        public async Task AddMultipleDimensionValue_ToASingleDimension()
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "Desc",
                IsActive = 1
            };

            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue firstDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "first value"
            };
            DomainModel.DomainModel.DimensionValue firstDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    firstDimensionValue, dimensionResult.Id)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue secondDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "second value"
            };

            // Act
            DomainModel.DomainModel.DimensionValue secondDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    secondDimensionValue, dimensionResult.Id)
               .ConfigureAwait(false);

            // Assert
            DomainModel.DomainModel.Dimension res = await masterDataBusinessLogic
               .GetValuesOfADimensionAsync(dimensionResult.Id)
               .ConfigureAwait(false);
            res.Should().NotBeNull();
            res.Name.Should().Be(dimension.Name);
            res.Description.Should().Be(dimension.Description);
            res.DimensionDimensionValues.Count.Should().Be(2);

            DimensionDimensionValue res1 = res.DimensionDimensionValues.FirstOrDefault(
                p => p.DimensionId == dimensionResult.Id
                 && p.DimensionValueId == firstDimensionValueResult.Id);
            res1.Should().NotBeNull();

            DimensionDimensionValue res2 = res.DimensionDimensionValues.FirstOrDefault(
                p => p.DimensionId == dimensionResult.Id
                 && p.DimensionValueId == secondDimensionValueResult.Id);
            res2.Should().NotBeNull();
        }

        [Fact]
        public async Task Create_AddDimensionValueAndConnectToDimension()
        {
            // Arrange
            DomainModel.DomainModel.Dimension alreadyExistingDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "Description",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension alreadyExistingDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    alreadyExistingDimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue secondDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "value"
            };

            // Act
            DomainModel.DomainModel.DimensionValue secondDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    secondDimensionValue, alreadyExistingDimensionResult.Id).ConfigureAwait(false);

            // Assert
            secondDimensionValueResult.Should().NotBeNull();
            secondDimensionValueResult.Id.Should().NotBe(0);
            secondDimensionValueResult.Value.Should().Be(secondDimensionValue.Value);
            secondDimensionValueResult.DimensionDimensionValues.Count.Should().Be(1);
        }

        [Fact]
        public async Task Create_DimensionValueDimensionRelation_WhenDimensionValueExist_ButNoDimensionRelation()
        {
            // Arrange
            DomainModel.DomainModel.Dimension alreadyExistingDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "Description",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension alreadyExistingDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    alreadyExistingDimension).ConfigureAwait(false);
            DomainModel.DomainModel.Dimension secondDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "Second dimension",
                Description = "Second dimension description",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension secondDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                secondDimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue alreadyExistingDimensionValue =
                new DomainModel.DomainModel.DimensionValue
                {
                    Value = "value"
                };
            DomainModel.DomainModel.DimensionValue alreadyExistingDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(alreadyExistingDimensionValue, alreadyExistingDimensionResult.Id)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue secondDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "value"
            };

            // Act
            DomainModel.DomainModel.DimensionValue secondDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    secondDimensionValue, secondDimensionResult.Id).ConfigureAwait(false);

            // Assert
            secondDimensionValueResult.Should().BeOfType<DomainModel.DomainModel.DimensionValue>();
            secondDimensionValueResult.Id.Should().NotBe(0);
            secondDimensionValueResult.Value.Should().Be(secondDimensionValue.Value);
            secondDimensionValueResult.DimensionDimensionValues.Count.Should().Be(1);
            secondDimensionValueResult.DimensionDimensionValues.FirstOrDefault(
                p => p.Id == secondDimensionResult.Id).Should().NotBeNull();
        }

        [Fact]
        public async Task Return_DimensionValue_WithRelatedEntities_WhenDimensionValueAndDimensionRelationAlreadyExist()
        {
            // Arrange
            DomainModel.DomainModel.Dimension alreadyExistingDimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "Description",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension alreadyExistingDimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(
                    alreadyExistingDimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue alreadyExistingDimensionValue =
                new DomainModel.DomainModel.DimensionValue
                {
                    Value = "value"
                };
            DomainModel.DomainModel.DimensionValue alreadyExistingDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(alreadyExistingDimensionValue, alreadyExistingDimensionResult.Id)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue secondDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "value"
            };

            // Act
            DomainModel.DomainModel.DimensionValue secondDimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    secondDimensionValue, alreadyExistingDimensionResult.Id).ConfigureAwait(false);

            // Assert
            secondDimensionValueResult.Should().NotBeNull();
            secondDimensionValueResult.Id.Should().Be(alreadyExistingDimensionValueResult.Id);
            secondDimensionValueResult.Value.Should().Be(alreadyExistingDimensionValueResult.Value);
            secondDimensionValueResult.DimensionDimensionValues.Count.Should().Be(1);
            DimensionDimensionValue res = secondDimensionValueResult.DimensionDimensionValues.ElementAt(0);
            DimensionDimensionValue orig = alreadyExistingDimensionValueResult
               .DimensionDimensionValues.ElementAt(0);
            res.Id.Should().Be(orig.Id);
            res.DimensionId.Should().Be(orig.DimensionId);
            res.DimensionValueId.Should().Be(orig.DimensionValueId);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchDimension()
        {
            // Arrange
            long dimensionId = 100;
            DomainModel.DomainModel.DimensionValue dimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "something string"
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionValueAsync(dimensionValue, dimensionId)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionValueAsyncOperationException>()
               .WithInnerExceptionExactly<MasterDataBusinessLogicNoSuchDimensionEntity>();
        }
    }
}
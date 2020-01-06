namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Xunit;

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
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "Desc",
                IsActive = 1
            };

            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DimensionValue firstDimensionValue = new DimensionValue
            {
                Value = "first value"
            };
            DimensionValue firstDimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                    firstDimensionValue, dimensionResult.Id)
                .ConfigureAwait(false);

            DimensionValue secondDimensionValue = new DimensionValue
            {
                Value = "second value"
            };

            // Act
            DimensionValue secondDimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                    secondDimensionValue, dimensionResult.Id)
                .ConfigureAwait(false);

            // Assert
            Dimension res = await masterDataBusinessLogic.GetValuesOfADimensionAsync(dimensionResult.Id)
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
            Dimension alreadyExistingDimension = new Dimension
            {
                Name = "name",
                Description = "Description",
                IsActive = 1
            };
            Dimension alreadyExistingDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                alreadyExistingDimension).ConfigureAwait(false);

            DimensionValue secondDimensionValue = new DimensionValue
            {
                Value = "value"
            };

            // Act
            DimensionValue secondDimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
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
            Dimension alreadyExistingDimension = new Dimension
            {
                Name = "name",
                Description = "Description",
                IsActive = 1
            };
            Dimension alreadyExistingDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                alreadyExistingDimension).ConfigureAwait(false);
            Dimension secondDimension = new Dimension
            {
                Name = "Second dimension",
                Description = "Second dimension description",
                IsActive = 1
            };
            Dimension secondDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                secondDimension).ConfigureAwait(false);

            DimensionValue alreadyExistingDimensionValue = new DimensionValue
            {
                Value = "value"
            };
            DimensionValue alreadyExistingDimensionValueResult = await masterDataBusinessLogic
                .AddDimensionValueAsync(alreadyExistingDimensionValue, alreadyExistingDimensionResult.Id)
                .ConfigureAwait(false);

            DimensionValue secondDimensionValue = new DimensionValue
            {
                Value = "value"
            };

            // Act
            DimensionValue secondDimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                secondDimensionValue, secondDimensionResult.Id).ConfigureAwait(false);

            // Assert
            secondDimensionValueResult.Should().BeOfType<DimensionValue>();
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
            Dimension alreadyExistingDimension = new Dimension
            {
                Name = "name",
                Description = "Description",
                IsActive = 1
            };
            Dimension alreadyExistingDimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                alreadyExistingDimension).ConfigureAwait(false);

            DimensionValue alreadyExistingDimensionValue = new DimensionValue
            {
                Value = "value"
            };
            DimensionValue alreadyExistingDimensionValueResult = await masterDataBusinessLogic
                .AddDimensionValueAsync(alreadyExistingDimensionValue, alreadyExistingDimensionResult.Id)
                .ConfigureAwait(false);

            DimensionValue secondDimensionValue = new DimensionValue
            {
                Value = "value"
            };

            // Act
            DimensionValue secondDimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
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
            DimensionValue dimensionValue = new DimensionValue
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
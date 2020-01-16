using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions;
using FluentAssertions;
using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionValue
{
    [ExcludeFromCodeCoverage]
    public class ModifyDimensionValue_Should : TestBase
    {
        public ModifyDimensionValue_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(ModifyDimensionValue_Should);

        [Fact]
        public async Task CreateANewDimensionValueForDimension_IfTheModifiedDimensionValueHasMultipleConnections()
        {
        }

        [Fact]
        public async Task ModifyDimensionValue_WhenTheModifiedValueHasASingleDimensionRelation()
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimVal1 = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval1"
            };
            DomainModel.DomainModel.DimensionValue dimVal1Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal1,
                dimensionResult.Id).ConfigureAwait(false);

            // Act
            DomainModel.DomainModel.DimensionValue dimval1Modified = new DomainModel.DomainModel.DimensionValue
            {
                Value = "super-duper value"
            };
            DomainModel.DomainModel.DimensionValue result = await masterDataBusinessLogic.ModifyDimensionValueAsync(
                dimensionResult.Id,
                dimVal1Result,
                dimval1Modified).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimVal1Result.Id);
            result.Value.Should().Be(dimval1Modified.Value);

            DomainModel.DomainModel.Dimension dimCheck = await masterDataBusinessLogic.GetValuesOfADimensionAsync(dimensionResult.Id)
                .ConfigureAwait(false);
            dimCheck.DimensionDimensionValues.Count.Should().Be(1);
            dimCheck.DimensionDimensionValues.ElementAt(0).DimensionValueId.Should().Be(dimVal1Result.Id);
            dimCheck.DimensionDimensionValues.ElementAt(0).DimensionValue.Value
                .Should().Be(dimval1Modified.Value);

            long count = await masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);
            count.Should().Be(1);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchDimension()
        {
            // Arrange
            DomainModel.DomainModel.DimensionValue oldDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Id = 101,
                Value = "asd"
            };

            DomainModel.DomainModel.DimensionValue newDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "asdasd"
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionValueAsync(100, oldDimensionValue, newDimensionValue)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicNoSuchDimensionEntity>();
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchDimensionDimensionValueRelation()
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimVal1 = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval1"
            };
            DomainModel.DomainModel.DimensionValue dimVal1Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal1,
                dimensionResult.Id).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimVal2 = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval2"
            };
            DomainModel.DomainModel.DimensionValue dimVal2Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal2,
                dimensionResult.Id).ConfigureAwait(false);

            DomainModel.DomainModel.Dimension dimension2 = new DomainModel.DomainModel.Dimension
            {
                Name = "dimension 2",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimension2Result = await masterDataBusinessLogic.AddDimensionAsync(dimension2)
                .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionValue dimVal3 = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval3"
            };
            DomainModel.DomainModel.DimensionValue dimVal3Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal3,
                dimension2Result.Id).ConfigureAwait(false);

            // Act
            DomainModel.DomainModel.DimensionValue dimVal3Modification = new DomainModel.DomainModel.DimensionValue
            {
                Value = "modified value"
            };
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionValueAsync(
                    dimension.Id,
                    dimVal3Result,
                    dimVal3Modification).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity>();
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchValue()
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue oldDimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Id = 101,
                Value = "old one"
            };

            DomainModel.DomainModel.DimensionValue modifiedOldOne = new DomainModel.DomainModel.DimensionValue
            {
                Value = "modified stuff"
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionValueAsync(
                        dimension.Id,
                        oldDimensionValue,
                        modifiedOldOne)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicNoSuchDimensionValueEntity>();
        }
    }
}
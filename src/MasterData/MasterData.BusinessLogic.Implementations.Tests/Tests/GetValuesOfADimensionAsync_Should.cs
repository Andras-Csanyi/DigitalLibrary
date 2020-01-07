namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class GetValuesOfADimensionAsync_Should : TestBase
    {
        public GetValuesOfADimensionAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(GetValuesOfADimensionAsync_Should);

        [Fact]
        public async Task Return_DimensionWithASingleDimensionValue()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DimensionValue dimensionValue = new DimensionValue
            {
                Value = "value"
            };
            DimensionValue dimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                    dimensionValue, dimensionResult.Id)
                .ConfigureAwait(false);

            // Act
            Dimension result = await masterDataBusinessLogic.GetValuesOfADimensionAsync(dimensionResult.Id)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.DimensionDimensionValues.Count.Should().Be(1);
            DimensionDimensionValue res = result.DimensionDimensionValues.FirstOrDefault();
            res.Id.Should().NotBe(0);
            res.DimensionId.Should().Be(dimensionResult.Id);
            res.DimensionValueId.Should().Be(dimensionValueResult.Id);
        }

        [Fact]
        public async Task Return_DimensionWithMultipleValues()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DimensionValue dimensionValue = new DimensionValue
            {
                Value = "value"
            };
            DimensionValue dimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                    dimensionValue, dimensionResult.Id)
                .ConfigureAwait(false);

            DimensionValue dimensionValue2 = new DimensionValue
            {
                Value = "value2"
            };
            DimensionValue dimensionValueResult2 = await masterDataBusinessLogic.AddDimensionValueAsync(
                    dimensionValue2, dimensionResult.Id)
                .ConfigureAwait(false);

            DimensionValue dimensionValue3 = new DimensionValue
            {
                Value = "value3"
            };
            DimensionValue dimensionValueResult3 = await masterDataBusinessLogic.AddDimensionValueAsync(
                    dimensionValue3, dimensionResult.Id)
                .ConfigureAwait(false);

            // Act
            Dimension result = await masterDataBusinessLogic.GetValuesOfADimensionAsync(dimensionResult.Id)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.DimensionDimensionValues.Count.Should().Be(3);

            DimensionDimensionValue res = result.DimensionDimensionValues
                .FirstOrDefault(p => p.DimensionValueId == dimensionValueResult.Id
                                     && p.DimensionId == dimensionResult.Id);
            res.Id.Should().NotBe(0);
            res.DimensionId.Should().Be(dimensionResult.Id);
            res.DimensionValueId.Should().Be(dimensionValueResult.Id);

            DimensionDimensionValue res2 = result.DimensionDimensionValues
                .FirstOrDefault(p => p.DimensionValueId == dimensionValueResult2.Id
                                     && p.DimensionId == dimensionResult.Id);
            res2.Id.Should().NotBe(0);
            res2.DimensionId.Should().Be(dimensionResult.Id);
            res2.DimensionValueId.Should().Be(dimensionValueResult2.Id);

            DimensionDimensionValue res3 = result.DimensionDimensionValues
                .FirstOrDefault(p => p.DimensionValueId == dimensionValueResult3.Id
                                     && p.DimensionId == dimensionResult.Id);
            res3.Id.Should().NotBe(0);
            res3.DimensionId.Should().Be(dimensionResult.Id);
            res3.DimensionValueId.Should().Be(dimensionValueResult3.Id);
        }

        [Fact]
        public async Task Return_JustDimension_WhenDimensionDoesntHaveValues()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            // Act
            Dimension result = await masterDataBusinessLogic.GetValuesOfADimensionAsync(dimensionResult.Id)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.DimensionDimensionValues.Should().BeEmpty();
        }

        [Fact]
        public async Task Return_Null_WhenThereIsNoDimension()
        {
            // Arrange

            // Act
            Dimension result = await masterDataBusinessLogic.GetValuesOfADimensionAsync(100)
                .ConfigureAwait(false);

            // Assert
            result.Should().BeNull();
        }
    }
}
namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class CountDimensionValues_Should : TestBase
    {
        public CountDimensionValues_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(CountDimensionValues_Should);

        [Fact]
        public async Task ReturnDimensionValuesCount_WhenASingleDimensionValueIsInTheSystem()
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
                Value = "dimval"
            };

            DimensionValue dimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimensionValue,
                dimensionResult.Id).ConfigureAwait(false);

            // Act
            long result = await masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public async Task ReturnDimensionValuesCount_WhenMultipleDimensionsHaveMultipleDimensionValues()
        {
            // Arrange
            Dimension dimension1 = new Dimension
            {
                Name = "name1",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimension1Result = await masterDataBusinessLogic.AddDimensionAsync(dimension1)
                .ConfigureAwait(false);

            DimensionValue dimension11Value = new DimensionValue
            {
                Value = "dimval11"
            };

            DimensionValue dimension11ValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimension11Value,
                dimension1Result.Id).ConfigureAwait(false);

            DimensionValue dimension12Value = new DimensionValue
            {
                Value = "dimval12"
            };

            DimensionValue dimensionValue12Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimension12Value,
                dimension1Result.Id).ConfigureAwait(false);


            Dimension dimension2 = new Dimension
            {
                Name = "name2",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimension2Result = await masterDataBusinessLogic.AddDimensionAsync(dimension2)
                .ConfigureAwait(false);

            DimensionValue dimension21Value = new DimensionValue
            {
                Value = "dimval21"
            };

            DimensionValue dimension21ValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimension21Value,
                dimension2Result.Id).ConfigureAwait(false);

            DimensionValue dimension22Value = new DimensionValue
            {
                Value = "dimval22"
            };

            DimensionValue dimensionValue22Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimension22Value,
                dimension2Result.Id).ConfigureAwait(false);

            // Act
            long result = await masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public async Task ReturnDimensionValuesCount_WhenMultipleDimensionValuesAreInTheSystem()
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
                Value = "dimval"
            };

            DimensionValue dimensionValueResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimensionValue,
                dimensionResult.Id).ConfigureAwait(false);

            DimensionValue dimensionValue2 = new DimensionValue
            {
                Value = "dimval2"
            };

            DimensionValue dimensionValue2Result = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimensionValue2,
                dimensionResult.Id).ConfigureAwait(false);

            // Act
            long result = await masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Should().Be(2);
        }
    }
}
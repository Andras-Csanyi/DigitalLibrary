namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

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
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval"
            };

            DomainModel.DomainModel.DimensionValue dimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
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
            DomainModel.DomainModel.Dimension dimension1 = new DomainModel.DomainModel.Dimension
            {
                Name = "name1",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimension1Result = await masterDataBusinessLogic
               .AddDimensionAsync(dimension1)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimension11Value = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval11"
            };

            DomainModel.DomainModel.DimensionValue dimension11ValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    dimension11Value,
                    dimension1Result.Id).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimension12Value = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval12"
            };

            DomainModel.DomainModel.DimensionValue dimensionValue12Result = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    dimension12Value,
                    dimension1Result.Id).ConfigureAwait(false);


            DomainModel.DomainModel.Dimension dimension2 = new DomainModel.DomainModel.Dimension
            {
                Name = "name2",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimension2Result = await masterDataBusinessLogic
               .AddDimensionAsync(dimension2)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimension21Value = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval21"
            };

            DomainModel.DomainModel.DimensionValue dimension21ValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    dimension21Value,
                    dimension2Result.Id).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimension22Value = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval22"
            };

            DomainModel.DomainModel.DimensionValue dimensionValue22Result = await masterDataBusinessLogic
               .AddDimensionValueAsync(
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
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic
               .AddDimensionAsync(dimension)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimensionValue = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval"
            };

            DomainModel.DomainModel.DimensionValue dimensionValueResult = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    dimensionValue,
                    dimensionResult.Id).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionValue dimensionValue2 = new DomainModel.DomainModel.DimensionValue
            {
                Value = "dimval2"
            };

            DomainModel.DomainModel.DimensionValue dimensionValue2Result = await masterDataBusinessLogic
               .AddDimensionValueAsync(
                    dimensionValue2,
                    dimensionResult.Id).ConfigureAwait(false);

            // Act
            long result = await masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Should().Be(2);
        }
    }
}
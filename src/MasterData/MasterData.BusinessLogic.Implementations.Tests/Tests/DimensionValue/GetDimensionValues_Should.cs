namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class GetDimensionValues_Should : TestBase
    {
        public GetDimensionValues_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(GetDimensionValues_Should);

        [Fact]
        public async Task ReturnAllDimensionValues_WhenASingleDimensionValueIsInTheSystem()
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
            List<DomainModel.DomainModel.DimensionValue> result =
                await masterDataBusinessLogic.GetDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(1);
            result.ElementAt(0).DimensionDimensionValues.Should().BeNull();
        }

        [Fact]
        public async Task ReturnAllDimensionValues_WhenMultipleDimensionsHaveMultipleDimensionValues()
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
            List<DomainModel.DomainModel.DimensionValue> result =
                await masterDataBusinessLogic.GetDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(4);
        }

        [Fact]
        public async Task ReturnAllDimensionValues_WhenMultipleDimensionValuesAreInTheSystem()
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
            List<DomainModel.DomainModel.DimensionValue> result =
                await masterDataBusinessLogic.GetDimensionValuesAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(2);
        }
    }
}
namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ModifyDimension_Should : TestBase
    {
        public ModifyDimension_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(ModifyDimension_Should);

        [Fact]
        public async Task ModifyDimension_WhenThereAreMultipleRelatedDimensionValues()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);
            DimensionValue dimVal = new DimensionValue
            {
                Value = "value"
            };
            DimensionValue dimValResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal, dimensionResult.Id).ConfigureAwait(false);
            DimensionValue dimval2 = new DimensionValue
            {
                Value = "value 2"
            };
            DimensionValue dimValResult2 = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimval2, dimensionResult.Id).ConfigureAwait(false);
            Dimension mod = new Dimension
            {
                Name = "modif",
                Description = "desc modif",
                IsActive = 1
            };

            // Act
            Dimension result = await masterDataBusinessLogic.ModifyDimensionAsync(dimensionResult.Id, mod)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(mod.Name);
            result.Description.Should().Be(mod.Description);
            result.IsActive.Should().Be(mod.IsActive);

            // get dimension for checking the relations
            Dimension modifDimension = await masterDataBusinessLogic.GetDimensionByIdAsync(dimensionResult.Id)
                .ConfigureAwait(false);
            modifDimension.DimensionDimensionValues.Count.Should().Be(2);
            modifDimension.DimensionDimensionValues.FirstOrDefault(
                p => p.DimensionValue.Value == dimVal.Value).Should().NotBeNull();
            modifDimension.DimensionDimensionValues.FirstOrDefault(
                p => p.DimensionValue.Value == dimval2.Value).Should().NotBeNull();
        }

        [Fact]
        public async Task ModifyDimension_WhenThereAreNoAnyRelatedDimensionValues()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            Dimension mod = new Dimension
            {
                Name = "modif",
                Description = "desc modif",
                IsActive = 1
            };

            // Act
            Dimension result = await masterDataBusinessLogic.ModifyDimensionAsync(dimensionResult.Id, mod)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(mod.Name);
            result.Description.Should().Be(mod.Description);
            result.IsActive.Should().Be(mod.IsActive);
            result.DimensionDimensionValues.Should().BeNull();
        }

        [Fact]
        public async Task ModifyDimension_WhenThereIsASingleRelatedDimensionValue()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);
            DimensionValue dimVal = new DimensionValue
            {
                Value = "value"
            };
            DimensionValue dimValResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal, dimensionResult.Id).ConfigureAwait(false);

            Dimension mod = new Dimension
            {
                Name = "modif",
                Description = "desc modif",
                IsActive = 1
            };

            // Act
            Dimension result = await masterDataBusinessLogic.ModifyDimensionAsync(dimensionResult.Id, mod)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(mod.Name);
            result.Description.Should().Be(mod.Description);
            result.IsActive.Should().Be(mod.IsActive);

            // get dimension for checking the relations
            Dimension modifDimension = await masterDataBusinessLogic.GetDimensionByIdAsync(dimensionResult.Id)
                .ConfigureAwait(false);
            modifDimension.DimensionDimensionValues.Count.Should().Be(1);
            modifDimension.DimensionDimensionValues.ElementAt(0).DimensionValue.Value.Should().Be(dimVal.Value);
        }
    }
}
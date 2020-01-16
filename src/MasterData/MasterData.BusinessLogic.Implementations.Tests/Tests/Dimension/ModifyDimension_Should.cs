using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.Dimension
{
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
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionValue dimVal = new DomainModel.DomainModel.DimensionValue
            {
                Value = "value"
            };
            DomainModel.DomainModel.DimensionValue dimValResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal, dimensionResult.Id).ConfigureAwait(false);
            DomainModel.DomainModel.DimensionValue dimval2 = new DomainModel.DomainModel.DimensionValue
            {
                Value = "value 2"
            };
            DomainModel.DomainModel.DimensionValue dimValResult2 = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimval2, dimensionResult.Id).ConfigureAwait(false);
            DomainModel.DomainModel.Dimension mod = new DomainModel.DomainModel.Dimension
            {
                Name = "modif",
                Description = "desc modif",
                IsActive = 1
            };

            // Act
            DomainModel.DomainModel.Dimension result = await masterDataBusinessLogic.ModifyDimensionAsync(dimensionResult.Id, mod)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(mod.Name);
            result.Description.Should().Be(mod.Description);
            result.IsActive.Should().Be(mod.IsActive);

            // get dimension for checking the relations
            DomainModel.DomainModel.Dimension modifDimension = await masterDataBusinessLogic.GetDimensionByIdAsync(dimensionResult.Id)
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
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);

            DomainModel.DomainModel.Dimension mod = new DomainModel.DomainModel.Dimension
            {
                Name = "modif",
                Description = "desc modif",
                IsActive = 1
            };

            // Act
            DomainModel.DomainModel.Dimension result = await masterDataBusinessLogic.ModifyDimensionAsync(dimensionResult.Id, mod)
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
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 0
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(dimension)
                .ConfigureAwait(false);
            DomainModel.DomainModel.DimensionValue dimVal = new DomainModel.DomainModel.DimensionValue
            {
                Value = "value"
            };
            DomainModel.DomainModel.DimensionValue dimValResult = await masterDataBusinessLogic.AddDimensionValueAsync(
                dimVal, dimensionResult.Id).ConfigureAwait(false);

            DomainModel.DomainModel.Dimension mod = new DomainModel.DomainModel.Dimension
            {
                Name = "modif",
                Description = "desc modif",
                IsActive = 1
            };

            // Act
            DomainModel.DomainModel.Dimension result = await masterDataBusinessLogic.ModifyDimensionAsync(dimensionResult.Id, mod)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(mod.Name);
            result.Description.Should().Be(mod.Description);
            result.IsActive.Should().Be(mod.IsActive);

            // get dimension for checking the relations
            DomainModel.DomainModel.Dimension modifDimension = await masterDataBusinessLogic.GetDimensionByIdAsync(dimensionResult.Id)
                .ConfigureAwait(false);
            modifDimension.DimensionDimensionValues.Count.Should().Be(1);
            modifDimension.DimensionDimensionValues.ElementAt(0).DimensionValue.Value.Should().Be(dimVal.Value);
        }
    }
}
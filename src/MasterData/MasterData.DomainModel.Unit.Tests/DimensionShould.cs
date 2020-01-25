namespace DigitalLibarary.MasterData.DomainModel.Unit.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;

    public class DimensionShould
    {
        public DimensionShould()
        {
        }

        [Fact]
        public async Task NotChangePropertyValues()
        {
            // Arrange
            long id = 10;
            string name = "name";
            string desc = "desc";
            int isActive = 1;
            List<DimensionDimensionValue> dimensionDimensionValues = new List<DimensionDimensionValue>
            {
                new DimensionDimensionValue { Id = 100, DimensionId = 100, DimensionValueId = 100 }
            };
            List<DimensionStructure> dimensionStructures = new List<DimensionStructure>
            {
                new DimensionStructure { Id = 100, Name = "name" }
            };

            // Act
            Dimension dimension = new Dimension
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive,
                DimensionDimensionValues = dimensionDimensionValues,
                DimensionStructure = dimensionStructures
            };

            // Assert
            dimension.Id.Should().Be(id);
            dimension.Name.Should().Be(name);
            dimension.Description.Should().Be(desc);
            dimension.IsActive.Should().Be(isActive);
            dimension.DimensionDimensionValues.Should().BeSameAs(dimensionDimensionValues);
            dimension.DimensionStructure.Should().BeSameAs(dimensionStructures);
        }
    }
}
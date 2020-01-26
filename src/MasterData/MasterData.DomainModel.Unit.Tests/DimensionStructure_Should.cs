namespace DigitalLibarary.MasterData.DomainModel.Unit.Tests
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;

    public class DimensionStructure_Should
    {
        [Fact]
        public async Task Properties_ShouldNotBeChangedBySetterAndGetter()
        {
            // Arrange
            long id = 100;
            string name = "name";
            string desc = "desc";
            int isActive = 1;

            // Act
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Assert
            dimensionStructure.Id.Should().Be(id);
            dimensionStructure.Name.Should().Be(name);
            dimensionStructure.Desc.Should().Be(desc);
            dimensionStructure.IsActive.Should().Be(isActive);
        }
    }
}
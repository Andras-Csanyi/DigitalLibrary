namespace DigitalLibarary.MasterData.DomainModel.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    public class DimensionStructure_Should
    {
        [Fact]
        public void Properties_ShouldNotBeChangedBySetterAndGetter()
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
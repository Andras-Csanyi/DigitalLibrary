namespace DigitalLibrary.MasterData.BusinessLogic.ViewModels.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class DimensionStructureQueryObjectShould
    {
        [Fact]
        public void NotChange_GetDimensionsStructuredById()
        {
            // Arrange
            DimensionStructureQueryObject obj = new();

            // Act
            obj.GetDimensionsStructuredById = 100;

            // Assert
            obj.GetDimensionsStructuredById.Should().Be(100);
        }
    }
}

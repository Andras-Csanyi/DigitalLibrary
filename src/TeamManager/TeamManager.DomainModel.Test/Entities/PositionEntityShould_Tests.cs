namespace DigitalLibrary.IaC.TeamManager.DomainModel.Test.Entities
{
    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    public class PositionEntityShould_Tests
    {
        [Trait("Category", "Unit")]
        public void ShouldNotChangeValues_DuringGetSetOperation()
        {
            // Arrange
            int id = 100;
            int isActive = 200;
            string name = "asfasd";

            // Act
            Position position = new Position
            {
                Id = id,
                IsActive = isActive,
                Name = name
            };

            // Assert
            position.Id.Should().Be(id);
            position.IsActive.Should().Be(isActive);
            position.Name.Should().Be(name);
        }
    }
}
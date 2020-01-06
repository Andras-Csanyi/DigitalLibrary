namespace DigitalLibrary.IaC.TeamManager.DomainModel.Test.Entities
{
    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    public class EventEntityShould_Tests
    {
        [Trait("Category", "Unit")]
        public void NotChageValue_DuringGetSetOperation()
        {
            // Arrange
            int id = 100;
            string name = "name";
            int isActive = 1;

            // Act
            Event eventEntity = new Event
            {
                Id = id,
                Name = name,
                IsActive = isActive
            };

            // Assert
            eventEntity.Id.Should().Be(id);
            eventEntity.Name.Should().Be(name);
            eventEntity.IsActive.Should().Be(isActive);
        }
    }
}
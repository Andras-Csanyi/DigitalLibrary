namespace DigitalLibrary.IaC.TeamManager.DomainModel.Test.Entities
{
    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    public class TitleEntityTests_Should
    {
        [Trait("Category", "Unit")]
        public void NotChange_InGetSetOperation()
        {
            // Arrange
            int id = 100;
            string name = "title";
            int isActive = 1;

            // Act
            Title title = new Title
            {
                Id = id,
                Name = name,
                IsActive = isActive
            };

            // Assert
            title.Id.Should().Be(id);
            title.Name.Should().Be(name);
            title.IsActive.Should().Be(isActive);
        }
    }
}
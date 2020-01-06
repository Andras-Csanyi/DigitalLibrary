namespace DigitalLibrary.IaC.TeamManager.DomainModel.Test.Entities
{
    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    public class PeopleEntityShould_Tests
    {
        [Trait("Category", "Unit")]
        public void ShouldNotChangeValue_DuringGetSetOperation()
        {
            // Arrange
            int id = 100;
            int isActive = 1;
            int titleId = 200;
            string lastName = "lastname";
            int companyId = 300;
            string firstName = "firstName";
            string middleName = "middleName";
            int positionId = 400;

            // Act
            People people = new People
            {
                Id = id,
                IsActive = isActive,
                TitleId = titleId,
                LastName = lastName,
                CompanyId = companyId,
                FirstName = firstName,
                MiddleName = middleName,
                PositionId = positionId
            };

            // Assert
            people.Id.Should().Be(id);
            people.IsActive.Should().Be(isActive);
            people.TitleId.Should().Be(titleId);
            people.LastName.Should().Be(lastName);
            people.CompanyId.Should().Be(companyId);
            people.FirstName.Should().Be(firstName);
            people.MiddleName.Should().Be(middleName);
            people.PositionId.Should().Be(positionId);
        }
    }
}
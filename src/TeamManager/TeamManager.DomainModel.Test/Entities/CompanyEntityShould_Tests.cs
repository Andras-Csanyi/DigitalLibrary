namespace DigitalLibrary.IaC.TeamManager.DomainModel.Test.Entities
{
    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    public class CompanyEntityShould_Tests
    {
        [Trait("Category", "Unit")]
        public void NotChangeValue_DuringSetGetOperation()
        {
            // Arrange
            int id = 100;
            string name = "name";
            string url = "url";
            string desc = "desc";

            // Act
            Company company = new Company
            {
                Id = id,
                Name = name,
                Url = url,
                Description = desc
            };

            // Assert
            company.Id.Should().Be(id);
            company.Name.Should().Be(name);
            company.Url.Should().Be(url);
            company.Description.Should().Be(desc);
        }
    }
}
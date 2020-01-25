namespace DigitalLibarary.MasterData.DomainModel.Unit.Tests
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;

    public class SourceFormat_Should
    {
        [Fact]
        public async Task PropertiesNotModifiedByGetSet()
        {
            // Arrange
            long id = 100;
            string name = "name";
            string desc = "desc";
            int isActive = 1;

            // Act
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive
            };

            // Assert
            sourceFormat.Id.Should().Be(id);
            sourceFormat.Name.Should().Be(name);
            sourceFormat.Desc.Should().Be(desc);
            sourceFormat.IsActive.Should().Be(isActive);
        }
    }
}
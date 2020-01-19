namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AddDimensionAsync_Should : TestBase
    {
        public AddDimensionAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(AddDimensionAsync_Should);

        [Fact]
        public async Task Add_ADimension()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };

            // Act
            Dimension result =
                await masterDataBusinessLogic.AddDimensionAsync(dimension).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Dimension>();
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(dimension.Name);
            result.Description.Should().Be(dimension.Description);
            result.IsActive.Should().Be(dimension.IsActive);
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

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
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };

            // Act
            DomainModel.DomainModel.Dimension result =
                await masterDataBusinessLogic.AddDimensionAsync(dimension).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<DomainModel.DomainModel.Dimension>();
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(dimension.Name);
            result.Description.Should().Be(dimension.Description);
            result.IsActive.Should().Be(dimension.IsActive);
        }
    }
}
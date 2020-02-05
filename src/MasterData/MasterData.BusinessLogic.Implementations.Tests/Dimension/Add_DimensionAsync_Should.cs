namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Add_DimensionAsync_Should : TestBase
    {
        public Add_DimensionAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Add_DimensionAsync_Should);

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
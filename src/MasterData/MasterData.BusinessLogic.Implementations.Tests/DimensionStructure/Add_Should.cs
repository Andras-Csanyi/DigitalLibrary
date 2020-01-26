namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Add_Should : TestBase
    {
        public Add_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Add_Should);

        [Fact]
        public async Task Add_DimensionStructure()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            // Act
            DimensionStructure result = await masterDataBusinessLogic.AddDimensionStructureAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(dimensionStructure.Name);
            result.Desc.Should().Be(dimensionStructure.Desc);
            result.IsActive.Should().Be(dimensionStructure.IsActive);
        }
    }
}
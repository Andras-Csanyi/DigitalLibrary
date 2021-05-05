namespace MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddAsync_Should : TestBase
    {
        [Theory]
        [InlineData("asd", "asd", 0)]
        [InlineData("dsa", "dsa", 1)]
        [InlineData("dsaasdasd", "dsa", 1)]
        [InlineData("dsa", "dsaasd", 1)]
        public async Task AddVariousEntities_WhenInputIsValid(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure newEntity = new DimensionStructure
            {
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Action
            DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(newEntity)
               .ConfigureAwait(false);

            // Assert
            result.Name.Should().Be(newEntity.Name);
            result.Desc.Should().Be(newEntity.Desc);
            result.IsActive.Should().Be(newEntity.IsActive);
        }

        public AddAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class UpdateAsync_Should : TestBase
    {
        [Theory]
        [InlineData("asdasd", "asdasd", 1)]
        [InlineData("dddddd", "dddddd", 0)]
        [InlineData("ddddd dfsd d", "dddf dfdf df", 1)]
        public async Task UpdateEntity(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure orig = _dimensionStructureFaker.Generate();
            DimensionStructure origResult = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(orig)
               .ConfigureAwait(false);
            DimensionStructure modify = new DimensionStructure()
            {
                Id = origResult.Id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Action
            DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .UpdateAsync(modify)
               .ConfigureAwait(false);

            // Assert
            result.Id.Should().Be(origResult.Id);
            result.Name.Should().Be(name);
            result.Desc.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }

        public UpdateAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
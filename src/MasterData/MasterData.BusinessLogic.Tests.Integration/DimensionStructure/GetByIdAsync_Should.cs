namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class GetByIdAsync_Should : TestBase
    {
        [Fact]
        public async Task Return_TheSpecifiedEntity()
        {
            // Arrange
            DimensionStructure orig = _dimensionStructureFaker.Generate();
            DimensionStructure origResult = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(orig)
               .ConfigureAwait(false);

            // Action
            DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetByIdAsync(origResult)
               .ConfigureAwait(false);

            // Assert
            result.Id.Should().Be(origResult.Id);
            result.Name.Should().Be(origResult.Name);
            result.Desc.Should().Be(origResult.Desc);
            result.IsActive.Should().Be(origResult.IsActive);
        }

        public GetByIdAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}

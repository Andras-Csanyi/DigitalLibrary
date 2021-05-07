namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    public class GetActiveAsync_Should : TestBase
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(0, 1)]
        public async Task Return_OnlyActives(
            int activeAmount,
            int inactiveAmount)
        {
            // Arrange
            await CreateActiveDimensionStructureEntities(activeAmount).ConfigureAwait(false);
            await CreateInactiveDimensionStructureEntities(inactiveAmount).ConfigureAwait(false);

            // Action
            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetActivesAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(activeAmount);
        }

        public GetActiveAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
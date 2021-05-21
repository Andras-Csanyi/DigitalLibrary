namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class DeleteAsync_Should : TestBase
    {
        [Fact]
        public async Task RemoveItem()
        {
            // Arrange
            IEnumerable<DimensionStructure> dimensionStructureInfinite = _dimensionStructureFaker.GenerateForever();
            DimensionStructure dimensionStructureOne = dimensionStructureInfinite.ElementAt(0);
            DimensionStructure dimensionStructureTwo = dimensionStructureInfinite.ElementAt(1);

            await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(dimensionStructureOne)
               .ConfigureAwait(false);

            DimensionStructure dimensionStructureTwoResult = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(dimensionStructureTwo)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .DeleteAsync(dimensionStructureTwoResult)
               .ConfigureAwait(false);

            // Assert
            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetAllAsync()
               .ConfigureAwait(false);

            result.Count.Should().Be(1);
            result.Where(w => w.Name == dimensionStructureTwo.Name).ToList().Count.Should().Be(0);
            result.Where(w => w.Name == dimensionStructureOne.Name).ToList().Count.Should().Be(1);
        }

        public DeleteAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}

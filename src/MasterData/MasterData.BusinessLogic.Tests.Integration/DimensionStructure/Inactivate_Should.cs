namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    public class Inactivate_Should : TestBase
    {
        [Fact]
        public async Task Inactivate_SpecifiedEntity()
        {
            // Arrange
            List<DimensionStructure> createdEntities = await CreateActiveDimensionStructureEntities(5);
            DimensionStructure toBeInactivated = createdEntities.ElementAt(3);

            // Action
            await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .InactivateAsync(toBeInactivated)
               .ConfigureAwait(false);

            // Assert
            DimensionStructure result = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .GetByIdAsync(toBeInactivated)
               .ConfigureAwait(false);
            result.IsActive.Should().Be(0);
            result.Name.Should().Be(toBeInactivated.Name);
            result.Desc.Should().Be(toBeInactivated.Desc);
            result.Id.Should().Be(toBeInactivated.Id);
        }

        public Inactivate_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Modify_Should : TestBase<DimensionStructure>
    {
        public Modify_Should(DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
                             ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            Dimension dimension1 = new Dimension
            {
                Name = "name11",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimension1Result = await masterDataHttpClient.AddDimensionAsync(dimension1)
               .ConfigureAwait(false);

            Dimension dimension2 = new Dimension
            {
                Name = "name211",
                Description = "desc2",
                IsActive = 1
            };
            Dimension dimension2Result = await masterDataHttpClient.AddDimensionAsync(dimension2)
               .ConfigureAwait(false);

            DimensionStructure top = new DimensionStructure
            {
                Name = "name2222",
                Desc = "desc",
                IsActive = 1,
            };
            DimensionStructure topResult = await masterDataHttpClient.AddTopDimensionStructureAsync(
                top).ConfigureAwait(false);

            DimensionStructure orig = new DimensionStructure
            {
                Name = "name212",
                Desc = "desc",
                IsActive = 1,
                ParentDimensionStructureId = topResult.Id,
                DimensionId = dimension1Result.Id
            };
            DimensionStructure origResult = await masterDataHttpClient.AddDimensionStructureAsync(
                orig).ConfigureAwait(false);

            DimensionStructure orig2 = new DimensionStructure
            {
                Name = "name21212",
                Desc = "desc2",
                IsActive = 1,
            };
            DimensionStructure orig2Result = await masterDataHttpClient.AddTopDimensionStructureAsync(
                orig2).ConfigureAwait(false);

            string updatedName = "modified name";
            string updatedDesc = "updated name";
            int updatedIsActive = 0;
            origResult.Name = updatedName;
            origResult.Desc = updatedDesc;
            origResult.IsActive = updatedIsActive;
            origResult.ParentDimensionStructureId = orig2Result.Id;
            origResult.DimensionId = dimension2Result.Id;

            // Act
            DimensionStructure updatedResult = await masterDataHttpClient.UpdateDimensionStructure(
                origResult).ConfigureAwait(false);

            // Assert
            updatedResult.Id.Should().Be(origResult.Id);
            updatedResult.Name.Should().Be(updatedName);
            updatedResult.Desc.Should().Be(updatedDesc);
            updatedResult.IsActive.Should().Be(updatedIsActive);
            updatedResult.ParentDimensionStructureId.Should().Be(orig2Result.Id);
            updatedResult.DimensionId.Should().Be(dimension2Result.Id);
        }
    }
}
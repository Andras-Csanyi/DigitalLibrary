using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
using FluentAssertions;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.DimensionStructure
{
    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public Add_Should(DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
                          ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Record_NewEntity()
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure topDimensionStructure = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "top",
                Desc = "top desc",
                IsActive = 1,
            };
            DomainModel.DomainModel.DimensionStructure topDimensionStructureResult = await masterDataHttpClient.AddTopDimensionStructureAsync(
                topDimensionStructure).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure dimensionStructure = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "dim",
                Desc = "dim",
                IsActive = 1,
                ParentDimensionStructureId = topDimensionStructureResult.Id
            };

            // Act
            DomainModel.DomainModel.DimensionStructure result = await masterDataHttpClient.AddDimensionStructureAsync(dimensionStructure)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(dimensionStructure.Name);
            result.Desc.Should().Be(dimensionStructure.Desc);
            result.IsActive.Should().Be(dimensionStructure.IsActive);
            result.ParentDimensionStructureId.Should().Be(dimensionStructure.ParentDimensionStructureId);
        }
    }
}
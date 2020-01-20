namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Should : TestBase<DimensionStructure>
    {
        public Add_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        // [Fact]
        public async Task Record_NewEntity()
        {
            // Arrange
            DimensionStructure topDimensionStructure =
                new DimensionStructure
                {
                    Name = "top",
                    Desc = "top desc",
                    IsActive = 1,
                };
            DimensionStructure topDimensionStructureResult = await masterDataHttpClient
               .AddTopDimensionStructureAsync(
                    topDimensionStructure).ConfigureAwait(false);

            DimensionStructure dimensionStructure =
                new DimensionStructure
                {
                    Name = "dim",
                    Desc = "dim",
                    IsActive = 1,
                };

            // Act
            DimensionStructure result = await masterDataHttpClient
               .AddDimensionStructureAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(dimensionStructure.Name);
            result.Desc.Should().Be(dimensionStructure.Desc);
            result.IsActive.Should().Be(dimensionStructure.IsActive);
        }
    }
}
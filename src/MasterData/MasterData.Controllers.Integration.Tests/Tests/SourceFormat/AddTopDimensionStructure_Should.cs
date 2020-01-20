namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
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
    public class AddTopDimensionStructure_Should : TestBase<DimensionStructure>
    {
        public AddTopDimensionStructure_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Add()
        {
            // Arrange
            DimensionStructure orig = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1
            };

            // Act
            DimensionStructure res = await masterDataHttpClient
               .AddTopDimensionStructureAsync(orig)
               .ConfigureAwait(false);

            // Assert
            res.Id.Should().NotBe(0);
            res.Name.Should().Be(orig.Name);
            res.Desc.Should().Be(orig.Desc);
            res.IsActive.Should().Be(orig.IsActive);
        }
    }
}
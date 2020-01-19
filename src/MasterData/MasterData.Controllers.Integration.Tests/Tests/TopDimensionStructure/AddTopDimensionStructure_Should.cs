namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.TopDimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class AddTopDimensionStructure_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public AddTopDimensionStructure_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Add()
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure orig = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1
            };

            // Act
            DomainModel.DomainModel.DimensionStructure res = await masterDataHttpClient
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
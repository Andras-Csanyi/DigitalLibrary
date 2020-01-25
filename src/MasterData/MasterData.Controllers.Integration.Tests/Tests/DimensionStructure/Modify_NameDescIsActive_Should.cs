namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Utils.IntegrationTestFactories.Factories;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Modify_NameDescIsActive_Should : TestBase<DimensionStructure>
    {
        public Modify_NameDescIsActive_Should(DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
                                              ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        // [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
        }
    }
}
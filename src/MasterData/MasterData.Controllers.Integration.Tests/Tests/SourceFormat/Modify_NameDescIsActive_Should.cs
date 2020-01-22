namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using Validators.TestData;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Modify_NameDescIsActive_Should : TestBase<DimensionStructure>
    {
        public Modify_NameDescIsActive_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Update_NameDescIsActive()
        {
            // Arrange
            string name = "name";
            string desc = "desc";
            int isActive = 0;

            SourceFormat orig = new SourceFormat
            {
                Name = "orig",
                Desc = "orig",
                IsActive = 1
            };
            SourceFormat origResult = await masterDataHttpClient
               .AddSourceFormatAsync(orig)
               .ConfigureAwait(false);

            origResult.Name = name;
            origResult.Desc = desc;
            origResult.IsActive = isActive;

            // Act
            SourceFormat result = await masterDataHttpClient
               .UpdateSourceFormatAsync(origResult)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(origResult.Id);
            result.Name.Should().Be(name);
            result.Desc.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }
    }
}
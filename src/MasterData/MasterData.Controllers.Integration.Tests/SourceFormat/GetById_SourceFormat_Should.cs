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
    public class GetById_SourceFormat_Should : TestBase<SourceFormat>
    {
        public GetById_SourceFormat_Should(DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
                                           ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_TheSourceFormat()
        {
            // Arrange
            SourceFormat sourceFormat1 = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1
            };
            SourceFormat sourceFormat1Result = await masterDataHttpClient.AddSourceFormatAsync(sourceFormat1)
               .ConfigureAwait(false);

            SourceFormat sourceFormat2 = new SourceFormat
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 1
            };
            SourceFormat sourceFormat2Result = await masterDataHttpClient.AddSourceFormatAsync(sourceFormat2)
               .ConfigureAwait(false);

            SourceFormat query = new SourceFormat
            {
                Id = sourceFormat2Result.Id,
            };
            // Act
            SourceFormat result = await masterDataHttpClient.GetSourceFormatById(query)
               .ConfigureAwait(false);

            // Result
            result.Id.Should().Be(sourceFormat2Result.Id);
            result.Name.Should().Be(sourceFormat2Result.Name);
            result.Desc.Should().Be(sourceFormat2Result.Desc);
            result.IsActive.Should().Be(sourceFormat2Result.IsActive);
        }
    }
}
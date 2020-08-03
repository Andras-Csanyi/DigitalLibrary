namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
{
    using System.Collections.Generic;
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
    public class Get_SourceFormat_Should : TestBase<SourceFormat>
    {
        public Get_SourceFormat_Should(
            DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_All()
        {
            // Arrange
            SourceFormat first = new SourceFormat
            {
                Name = "first",
                Desc = "second",
                IsActive = 1,
            };
            SourceFormat firstResult = await masterDataHttpClient
               .AddSourceFormatAsync(first)
               .ConfigureAwait(false);

            SourceFormat second = new SourceFormat
            {
                Name = "second",
                Desc = "second",
                IsActive = 0
            };
            SourceFormat secondResult = await masterDataHttpClient
               .AddSourceFormatAsync(second)
               .ConfigureAwait(false);

            // Act
            List<SourceFormat> result = await masterDataHttpClient
               .GetSourceFormatsAsync()
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
        }
    }
}
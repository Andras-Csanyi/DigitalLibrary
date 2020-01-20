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
    public class Delete_SourceFormat_Should : TestBase<DimensionStructure>
    {
        public Delete_SourceFormat_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        // [Fact]
        public async Task DeleteTheItem()
        {
            // Arrange
            DimensionStructure first = new DimensionStructure
            {
                Name = "first",
                Desc = "second",
                IsActive = 1,
            };
            DimensionStructure firstResult = await masterDataHttpClient
               .AddTopDimensionStructureAsync(first)
               .ConfigureAwait(false);

            DimensionStructure second = new DimensionStructure
            {
                Name = "second",
                Desc = "second",
                IsActive = 0
            };
            DimensionStructure secondResult = await masterDataHttpClient
               .AddTopDimensionStructureAsync(second)
               .ConfigureAwait(false);
            List<DimensionStructure> origRes = await masterDataHttpClient
               .GetTopDimensionStructuresAsync()
               .ConfigureAwait(false);
            int origResCount = origRes.Count;

            // Act
            await masterDataHttpClient.DeleteTopDimensionStructureAsync(secondResult).ConfigureAwait(false);

            // Assert
            List<DimensionStructure> res = await masterDataHttpClient
               .GetTopDimensionStructuresAsync()
               .ConfigureAwait(false);
            res.Count.Should().Be(origResCount - 1);
        }
    }
}
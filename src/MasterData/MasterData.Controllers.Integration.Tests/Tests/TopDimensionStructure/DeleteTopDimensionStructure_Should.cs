using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
using FluentAssertions;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.TopDimensionStructure
{
    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class DeleteTopDimensionStructure_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public DeleteTopDimensionStructure_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task DeleteTheItem()
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure first = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "first",
                Desc = "second",
                IsActive = 1,
            };
            DomainModel.DomainModel.DimensionStructure firstResult = await masterDataHttpClient.AddTopDimensionStructureAsync(first)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure second = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "second",
                Desc = "second",
                IsActive = 0
            };
            DomainModel.DomainModel.DimensionStructure secondResult = await masterDataHttpClient.AddTopDimensionStructureAsync(second)
                .ConfigureAwait(false);
            List<DomainModel.DomainModel.DimensionStructure> origRes = await masterDataHttpClient.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);
            int origResCount = origRes.Count;

            // Act
            await masterDataHttpClient.DeleteTopDimensionStructureAsync(secondResult).ConfigureAwait(false);

            // Assert
            List<DomainModel.DomainModel.DimensionStructure> res = await masterDataHttpClient.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);
            res.Count.Should().Be(origResCount - 1);
        }
    }
}
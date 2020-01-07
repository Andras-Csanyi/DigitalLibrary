namespace DigitalLibrary.IaC.MasterData.QA.Integration.Tests.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Factories;

    using FluentAssertions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.MasterData.QA.Integration.Tests")]
    public class DeleteTopDimensionStructure_Should : TestBase<DimensionStructure>
    {
        public DeleteTopDimensionStructure_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task DeleteTheItem()
        {
            // Arrange
            DimensionStructure first = new DimensionStructure
            {
                Name = "first",
                Desc = "second",
                IsActive = 1,
            };
            DimensionStructure firstResult = await masterDataHttpClient.AddTopDimensionStructureAsync(first)
                .ConfigureAwait(false);

            DimensionStructure second = new DimensionStructure
            {
                Name = "second",
                Desc = "second",
                IsActive = 0
            };
            DimensionStructure secondResult = await masterDataHttpClient.AddTopDimensionStructureAsync(second)
                .ConfigureAwait(false);
            List<DimensionStructure> origRes = await masterDataHttpClient.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);
            int origResCount = origRes.Count;

            // Act
            await masterDataHttpClient.DeleteTopDimensionStructureAsync(secondResult).ConfigureAwait(false);

            // Assert
            List<DimensionStructure> res = await masterDataHttpClient.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);
            res.Count.Should().Be(origResCount - 1);
        }
    }
}
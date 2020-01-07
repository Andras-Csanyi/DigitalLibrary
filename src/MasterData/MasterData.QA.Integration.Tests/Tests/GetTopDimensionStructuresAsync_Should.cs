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
    public class MasterData_Api_GetTopDimensionStructuresAsync_Should : TestBase<DimensionStructure>
    {
        public MasterData_Api_GetTopDimensionStructuresAsync_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_AllTopDimensionStructures()
        {
            // Arrange

            // Act
            List<DimensionStructure> result = await masterDataHttpClient.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }
    }
}
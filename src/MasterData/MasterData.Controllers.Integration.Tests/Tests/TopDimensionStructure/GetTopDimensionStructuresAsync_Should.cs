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
    public class MasterData_Api_GetTopDimensionStructuresAsync_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public MasterData_Api_GetTopDimensionStructuresAsync_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_AllTopDimensionStructures()
        {
            // Arrange

            // Act
            List<DomainModel.DomainModel.DimensionStructure> result = await masterDataHttpClient.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }
    }
}
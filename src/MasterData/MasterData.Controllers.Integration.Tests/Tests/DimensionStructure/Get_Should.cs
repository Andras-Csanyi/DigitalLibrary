using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
using FluentAssertions;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.DimensionStructure
{
    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Get_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public Get_Should(DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
                          ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_All()
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure topDimensionStructure = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.DimensionStructure topDimensionStructureResult = await masterDataHttpClient
                .AddTopDimensionStructureAsync(topDimensionStructure)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure dimensionStructure1 = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "list1",
                Desc = "list1",
                IsActive = 1,
                ParentDimensionStructureId = topDimensionStructureResult.Id
            };
            DomainModel.DomainModel.DimensionStructure dimensionStructure1Result = await masterDataHttpClient
                .AddDimensionStructureAsync(dimensionStructure1)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure dimensionStructure2 = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "list2",
                Desc = "list2",
                IsActive = 1,
                ParentDimensionStructureId = topDimensionStructureResult.Id
            };
            DomainModel.DomainModel.DimensionStructure dimensionStructure2Result = await masterDataHttpClient
                .AddDimensionStructureAsync(dimensionStructure2)
                .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure dimensionStructure3 = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "list3",
                Desc = "list3",
                IsActive = 1,
                ParentDimensionStructureId = topDimensionStructureResult.Id
            };
            DomainModel.DomainModel.DimensionStructure dimensionStructure3Result = await masterDataHttpClient
                .AddDimensionStructureAsync(dimensionStructure3)
                .ConfigureAwait(false);

            // Act
            List<DomainModel.DomainModel.DimensionStructure> dimensionStructures = await masterDataHttpClient.GetDimensionStructuresAsync()
                .ConfigureAwait(false);

            // Assert
            dimensionStructures.Should().NotBeNull();
            dimensionStructures.Count.Should().Be(3);
            dimensionStructures.Count(n => n.Name == dimensionStructure1.Name).Should().Be(1);
            dimensionStructures.Count(n => n.Name == dimensionStructure2.Name).Should().Be(1);
            dimensionStructures.Count(n => n.Name == dimensionStructure3.Name).Should().Be(1);
        }
    }
}
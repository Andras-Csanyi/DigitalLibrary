// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class Get_Should : TestBase<DimensionStructure>
    {
        public Get_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_All()
        {
            // Arrange
            DimensionStructure dimensionStructure1 = new DimensionStructure
            {
                Name = "list1",
                Desc = "list1",
                IsActive = 1,
            };
            DimensionStructure dimensionStructure1Result = await _masterDataHttpClient
               .AddDimensionStructureAsync(dimensionStructure1)
               .ConfigureAwait(false);

            DimensionStructure dimensionStructure2 = new DimensionStructure
            {
                Name = "list2",
                Desc = "list2",
                IsActive = 1,
            };
            DimensionStructure dimensionStructure2Result = await _masterDataHttpClient
               .AddDimensionStructureAsync(dimensionStructure2)
               .ConfigureAwait(false);

            DimensionStructure dimensionStructure3 = new DimensionStructure
            {
                Name = "list3",
                Desc = "list3",
                IsActive = 0,
            };
            DimensionStructure dimensionStructure3Result = await _masterDataHttpClient
               .AddDimensionStructureAsync(dimensionStructure3)
               .ConfigureAwait(false);

            // Act
            List<DimensionStructure> dimensionStructures = await _masterDataHttpClient
               .GetDimensionStructuresAsync()
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
namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Should : TestBase<DimensionStructure>
    {
        public Add_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Record_NewEntity()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "dim",
                Desc = "dim",
                IsActive = 1,
            };

            // Act
            DimensionStructure result = await masterDataHttpClient
               .AddDimensionStructureAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(dimensionStructure.Name);
            result.Desc.Should().Be(dimensionStructure.Desc);
            result.IsActive.Should().Be(dimensionStructure.IsActive);
        }

        [Fact]
        public async Task ThrowException_WhenUniqueNameConstraintViolated()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "dim22",
                Desc = "dim22",
                IsActive = 1,
            };

            DimensionStructure result = await masterDataHttpClient
               .AddDimensionStructureAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient
                   .AddDimensionStructureAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
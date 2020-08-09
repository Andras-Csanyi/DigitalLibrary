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
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Modify_NameDescIsActive_Should : TestBase<DimensionStructure>
    {
        public Modify_NameDescIsActive_Should(DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
                                              ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public void ThrowException_WhenThereIsNoSuchEntity()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = 400
            };

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.UpdateDimensionStructureAsync(dimensionStructure)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }

        [Fact]
        public async Task Update_TheItem()
        {
            // Arrange
            string name = "name";
            string desc = "desc";
            int isActive = 0;

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "asdasdasd",
                Desc = "dedede",
                IsActive = 1,
            };
            DimensionStructure dimensionStructureResult = await _masterDataHttpClient.AddDimensionStructureAsync(
                    dimensionStructure)
               .ConfigureAwait(false);

            dimensionStructureResult.Name = name;
            dimensionStructureResult.Desc = desc;
            dimensionStructureResult.IsActive = isActive;

            // Act
            DimensionStructure result = await _masterDataHttpClient.UpdateDimensionStructureAsync(
                    dimensionStructureResult)
               .ConfigureAwait(false);

            // Assert
            result.Id.Should().Be(dimensionStructureResult.Id);
            result.Name.Should().Be(name);
            result.Desc.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }
    }
}
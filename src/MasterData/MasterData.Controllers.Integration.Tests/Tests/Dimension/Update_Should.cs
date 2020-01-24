namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
{
    using System;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    public class Update_Should : TestBase<Dimension>
    {
        public Update_Should(DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
                             ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Update_TheItem()
        {
            // Arrange
            string name = "asdasd";
            string desc = "asdasdasdasd";
            int isActive = 0;

            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimensionResult = await masterDataHttpClient.AddDimensionAsync(dimension).ConfigureAwait(false);

            dimensionResult.Name = name;
            dimensionResult.Description = desc;
            dimensionResult.IsActive = isActive;

            // Act
            Dimension result = await masterDataHttpClient.UpdateDimensionAsync(dimensionResult)
               .ConfigureAwait(false);

            // Assert
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(name);
            result.Description.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchEntity()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = 100,
                Name = "asdasd",
                Description = "dedwedwe",
                IsActive = 1
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.UpdateDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
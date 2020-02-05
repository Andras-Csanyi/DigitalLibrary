namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
    public class Delete_Should : TestBase<Dimension>
    {
        public Delete_Should(DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
                             ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Delete_TheItem()
        {
            // Arrange
            Dimension dimension1 = new Dimension
            {
                Name = "asdasd",
                Description = "asdad",
                IsActive = 1
            };
            Dimension dimension1Result = await masterDataHttpClient.AddDimensionAsync(dimension1)
               .ConfigureAwait(false);

            Dimension dimension2 = new Dimension
            {
                Name = "qweqwe",
                Description = "qweqwe",
                IsActive = 0
            };
            Dimension dimension2Result = await masterDataHttpClient.AddDimensionAsync(dimension2)
               .ConfigureAwait(false);

            // Act
            await masterDataHttpClient.DeleteDimensionAsync(dimension2Result)
               .ConfigureAwait(false);

            // Assert
            List<Dimension> result = await masterDataHttpClient.GetDimensionsAsync().ConfigureAwait(false);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result.Where(p => p.Name == dimension1.Name).ToList().Count.Should().Be(1);
            result.Where(p => p.Name == dimension2.Name).ToList().Count.Should().Be(0);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoSuchEntity()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = 1000
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.DeleteDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
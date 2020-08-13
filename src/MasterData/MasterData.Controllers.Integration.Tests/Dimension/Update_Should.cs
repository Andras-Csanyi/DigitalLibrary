// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
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
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class Update_Should : TestBase<Dimension>
    {
        public Update_Should(DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
                             ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task ThrowException_WhenNameUniqueConstraintIsViolated()
        {
            // Arrange
            string name = "qqqqqqqqqqqqqqqqqq";
            string desc = "qqqqqqqqqqqqqqqqqq";
            int isActive = 0;

            Dimension orig = new Dimension
            {
                Name = name,
                Description = desc,
                IsActive = isActive
            };
            Dimension origResult = await _masterDataHttpClient.AddDimensionAsync(orig)
               .ConfigureAwait(false);

            Dimension dimension = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimensionResult = await _masterDataHttpClient.AddDimensionAsync(dimension).ConfigureAwait(false);

            dimensionResult.Name = name;
            dimensionResult.Description = desc;
            dimensionResult.IsActive = isActive;

            // Act
            Func<Task> action = async () =>
            {
                await _masterDataHttpClient.UpdateDimensionAsync(dimensionResult).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }

        [Fact]
        public void ThrowException_WhenThereIsNoSuchEntity()
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
                await _masterDataHttpClient.UpdateDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
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
            Dimension dimensionResult = await _masterDataHttpClient.AddDimensionAsync(dimension).ConfigureAwait(false);

            dimensionResult.Name = name;
            dimensionResult.Description = desc;
            dimensionResult.IsActive = isActive;

            // Act
            Dimension result = await _masterDataHttpClient.UpdateDimensionAsync(dimensionResult)
               .ConfigureAwait(false);

            // Assert
            result.Id.Should().Be(dimensionResult.Id);
            result.Name.Should().Be(name);
            result.Description.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }
    }
}
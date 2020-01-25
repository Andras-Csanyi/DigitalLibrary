namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
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
    public class Add_Should : TestBase<SourceFormat>
    {
        public Add_Should(
            DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
            ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task Add()
        {
            // Arrange
            SourceFormat orig = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1
            };

            // Act
            SourceFormat res = await masterDataHttpClient
               .AddSourceFormatAsync(orig)
               .ConfigureAwait(false);

            // Assert
            res.Id.Should().NotBe(0);
            res.Name.Should().Be(orig.Name);
            res.Desc.Should().Be(orig.Desc);
            res.IsActive.Should().Be(orig.IsActive);
        }

        [Fact]
        public async Task ThrowsException_WhenUniqueNameConstraintViolated()
        {
            // Arrange
            SourceFormat orig = new SourceFormat
            {
                Name = "nameqqqqq",
                Desc = "desc",
                IsActive = 1
            };

            SourceFormat res = await masterDataHttpClient.AddSourceFormatAsync(orig)
               .ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.AddSourceFormatAsync(orig).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
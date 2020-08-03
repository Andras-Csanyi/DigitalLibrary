namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.SourceFormat
{
    using System;
    using System.Collections.Generic;
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
    public class Delete_SourceFormat_Should : TestBase<SourceFormat>
    {
        public Delete_SourceFormat_Should(
            DiLibMasterDataWebApplicationFactory<Startup, SourceFormat> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task DeleteTheItem()
        {
            // Arrange
            SourceFormat first = new SourceFormat
            {
                Name = "first",
                Desc = "second",
                IsActive = 1,
            };
            SourceFormat firstResult = await masterDataHttpClient
               .AddSourceFormatAsync(first)
               .ConfigureAwait(false);

            SourceFormat second = new SourceFormat
            {
                Name = "second",
                Desc = "second",
                IsActive = 0
            };
            SourceFormat secondResult = await masterDataHttpClient
               .AddSourceFormatAsync(second)
               .ConfigureAwait(false);
            List<SourceFormat> origRes = await masterDataHttpClient
               .GetSourceFormatsAsync()
               .ConfigureAwait(false);
            int origResCount = origRes.Count;

            // Act
            await masterDataHttpClient.DeleteSourceFormatAsync(secondResult).ConfigureAwait(false);

            // Assert
            List<SourceFormat> res = await masterDataHttpClient
               .GetSourceFormatsAsync()
               .ConfigureAwait(false);
            res.Count.Should().Be(origResCount - 1);
        }

        [Fact]
        public async Task ThrowException_WhenEntityDoesntExist()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat { Id = 100 };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.DeleteSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
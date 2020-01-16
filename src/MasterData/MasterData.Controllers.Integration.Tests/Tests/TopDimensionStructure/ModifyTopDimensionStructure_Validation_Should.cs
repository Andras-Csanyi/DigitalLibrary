using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.WebApi.Client.Client;
using DigitalLibrary.Utils.DiLibHttpClient.Exceptions;
using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
using FluentAssertions;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.TopDimensionStructure
{
    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class ModifyTopDimensionStructure_Validation_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public ModifyTopDimensionStructure_Validation_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.ModifyTopDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>()
                .WithInnerException<DiLibHttpClientPutException>();
        }
    }
}
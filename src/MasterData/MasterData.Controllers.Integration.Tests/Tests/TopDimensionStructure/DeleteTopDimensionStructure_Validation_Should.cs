namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.TopDimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Utils.DiLibHttpClient.Exceptions;
    using Utils.IntegrationTestFactories.Factories;

    using WebApi.Client.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class DeleteTopDimensionStructure_Validation_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public DeleteTopDimensionStructure_Validation_Should(
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
                await masterDataHttpClient.DeleteTopDimensionStructureAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>()
               .WithInnerException<DiLibHttpClientDeleteException>();
        }
    }
}
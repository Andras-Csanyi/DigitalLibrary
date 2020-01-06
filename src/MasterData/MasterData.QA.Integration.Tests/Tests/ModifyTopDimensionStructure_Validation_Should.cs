namespace DigitalLibrary.IaC.MasterData.QA.Integration.Tests.Tests
{
    using System;
    using System.Threading.Tasks;

    using DiLibHttpClient.Exceptions;

    using DomainModel.DomainModel;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.MasterData.QA.Integration.Tests")]
    public class ModifyTopDimensionStructure_Validation_Should : TestBase<DimensionStructure>
    {
        public ModifyTopDimensionStructure_Validation_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
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
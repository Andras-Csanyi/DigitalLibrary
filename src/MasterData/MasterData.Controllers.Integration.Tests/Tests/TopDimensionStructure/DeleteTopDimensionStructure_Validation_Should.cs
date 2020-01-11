namespace DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests.Tests.TopDimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DiLibHttpClient.Exceptions;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using QA.Integration.Tests.Factories;

    using WebApi.Client.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class DeleteTopDimensionStructure_Validation_Should : TestBase<DimensionStructure>
    {
        public DeleteTopDimensionStructure_Validation_Should(
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
                await masterDataHttpClient.DeleteTopDimensionStructureAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>()
                .WithInnerException<DiLibHttpClientDeleteException>();
        }
    }
}
namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Dimension
{
    using System;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using Validators.TestData;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    public class Update_Validation_Should : TestBase<Dimension>
    {
        public Update_Validation_Should(DiLibMasterDataWebApplicationFactory<Startup, Dimension> host,
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
                await masterDataHttpClient.AddDimensionAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }

        [Theory]
        [MemberData(nameof(MasterData_Dimension_TestData.UpdateDimensionAsync_Validation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive,
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
namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using Validators.TestData;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Validation_Should : TestBase<DimensionStructure>
    {
        public Add_Validation_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.AddDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task Throw_Exception_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.AddDimensionStructureAsync(dimensionStructure).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }

        [Fact]
        public async Task Throw_Exception_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.AddDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
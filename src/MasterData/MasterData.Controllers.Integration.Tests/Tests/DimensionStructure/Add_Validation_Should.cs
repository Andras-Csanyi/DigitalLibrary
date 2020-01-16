using IntegrationTestFactories.Factories;

namespace DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;
    using SQLitePCL;

    using Validators.TestData.TestData;

    using WebApi.Client.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Validation_Should : TestBase<DimensionStructure>
    {
        public Add_Validation_Should(DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
                                     ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
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

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.AddDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task Throw_Exception_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive,
            long parentId)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
                ParentDimensionStructureId = parentId
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.AddDimensionStructureAsync(dimensionStructure).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.Validators.TestData.TestData;
using DigitalLibrary.MasterData.WebApi.Client.Client;
using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
using FluentAssertions;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.DimensionStructure
{
    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Add_Validation_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public Add_Validation_Should(DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
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
            DomainModel.DomainModel.DimensionStructure dimensionStructure = new DomainModel.DomainModel.DimensionStructure
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
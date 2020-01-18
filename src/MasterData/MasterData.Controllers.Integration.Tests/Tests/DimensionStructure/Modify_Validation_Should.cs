namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using Utils.IntegrationTestFactories.Factories;

    using Validators.TestData.TestData;

    using WebApi.Client.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class Modify_Validation_Should : TestBase<DimensionStructure>
    {
        public Modify_Validation_Should(DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
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
                await masterDataHttpClient.UpdateDimensionStructure(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.ModifyDimensionStructure_Validation_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive,
            long parentDimensionStructureId)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
                ParentDimensionStructureId = parentDimensionStructureId,
            };
            
            // Act
            Func<Task> action = async () =>
            {
                await masterDataHttpClient.UpdateDimensionStructure(dimensionStructure)
                    .ConfigureAwait(false);
            };
            
            // Assert
            action.Should().ThrowExactly<MasterDataHttpClientException>();
        }
    }
}
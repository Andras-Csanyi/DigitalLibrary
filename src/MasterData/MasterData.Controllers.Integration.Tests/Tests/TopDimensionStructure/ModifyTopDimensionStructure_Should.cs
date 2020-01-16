using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.Validators.TestData.TestData;
using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
using FluentAssertions;
using WebApp;
using Xunit;
using Xunit.Abstractions;

namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.Tests.TopDimensionStructure
{
    [ExcludeFromCodeCoverage]
    [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
    public class ModifyTopDimensionStructure_Should : TestBase<DomainModel.DomainModel.DimensionStructure>
    {
        public ModifyTopDimensionStructure_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DomainModel.DomainModel.DimensionStructure> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }


        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task ModifyTopDimensionStructure(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure orig = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "orig",
                Desc = "orig",
                IsActive = 1
            };
            DomainModel.DomainModel.DimensionStructure origResult = await masterDataHttpClient.AddTopDimensionStructureAsync(orig)
                .ConfigureAwait(false);

            origResult.Name = name;
            origResult.Desc = desc;
            origResult.IsActive = isActive;

            // Act
            DomainModel.DomainModel.DimensionStructure result = await masterDataHttpClient.ModifyTopDimensionStructureAsync(origResult)
                .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(origResult.Id);
            result.Name.Should().Be(name);
            result.Desc.Should().Be(desc);
            result.IsActive.Should().Be(isActive);
        }
    }
}
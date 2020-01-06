namespace DigitalLibrary.IaC.MasterData.QA.Integration.Tests.Tests
{
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Factories;

    using FluentAssertions;

    using Validators.TestData.TestData;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.MasterData.QA.Integration.Tests")]
    public class ModifyTopDimensionStructure_Should : TestBase<DimensionStructure>
    {
        public ModifyTopDimensionStructure_Should(
            DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
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
            DimensionStructure orig = new DimensionStructure
            {
                Name = "orig",
                Desc = "orig",
                IsActive = 1
            };
            DimensionStructure origResult = await masterDataHttpClient.AddTopDimensionStructureAsync(orig)
                .ConfigureAwait(false);

            origResult.Name = name;
            origResult.Desc = desc;
            origResult.IsActive = isActive;

            // Act
            DimensionStructure result = await masterDataHttpClient.ModifyTopDimensionStructureAsync(origResult)
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
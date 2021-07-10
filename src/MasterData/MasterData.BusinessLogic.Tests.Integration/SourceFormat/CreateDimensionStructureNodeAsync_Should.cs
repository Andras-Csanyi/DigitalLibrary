namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Tests.TestData.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class CreateDimensionStructureNodeAsync_Should : TestBase
    {
        public CreateDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper) : base(
            testOutputHelper)
        {
        }


        [Theory]
        [ClassData(typeof(Create_DimensionStructureNode_TestData))]
        public async Task CreateEntity(long Id, int IsActive)
        {
            // Arrange
            DimensionStructureNode node = new DimensionStructureNode
            {
                Id = Id,
                IsActive = IsActive,
            };

            // Action
            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .CreateDimensionStructureNodeAsync(node)
               .ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
            result.IsActive.Should().Be(IsActive);
        }
    }
}

namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddDimensionStructureNodeAsync_Should : TestBase
    {
        [Fact]
        public async Task Add_ChildNodeToRootDsn()
        {
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode root = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, root.Id).ConfigureAwait(false);

            DimensionStructureNode child = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(child.Id, root.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureNodeTreeAsync(sf)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.DimensionStructureNode.ChildNodes.ElementAt(0).Id
               .Should().Be(child.Id);
        }

        public AddDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
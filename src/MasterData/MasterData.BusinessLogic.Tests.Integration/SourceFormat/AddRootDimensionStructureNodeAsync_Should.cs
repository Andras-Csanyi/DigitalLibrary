namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddRootDimensionStructureNodeAsync_Should : TestBase
    {
        [Fact]
        public async Task Add_DSNToSourceFormatAsRoot()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode dimensionStructureNode = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, dimensionStructureNode.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(sourceFormat)
               .ConfigureAwait(false);

            result.SourceFormatDimensionStructureNode.Id.Should().Be(dimensionStructureNode.Id);
        }

        public AddRootDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
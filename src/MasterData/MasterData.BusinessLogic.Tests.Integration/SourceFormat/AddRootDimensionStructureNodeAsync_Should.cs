namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
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

        [Fact]
        public async Task Throw_WhenSourceFormatAlreadyHaveARootDimensionStructureNode()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode root = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            DimensionStructureNode second = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, root.Id)
               .ConfigureAwait(false);

            // Action
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddRootDimensionStructureNodeAsync(sourceFormat.Id, second.Id)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        public AddRootDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}

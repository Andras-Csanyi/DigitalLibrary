namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class DeleteAsync_Should : TestBase
    {
        [Fact]
        public async Task Throws_WhenNoSuchSourceFormat()
        {
            // Arrange
            SourceFormat sourceFormat = new() { Id = 100 };

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        [Fact]
        public async Task Delete_SourceFormat()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity()
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteAsync(sourceFormat)
               .ConfigureAwait(false);

            // Assert
            List<SourceFormat> result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAllAsync()
               .ConfigureAwait(false);
            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task Deletes_RootDimensionStructureNodeToo()
        {
            // Arrange
            SourceFormat sourceFormatOrig = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode dimensionStructureNode = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormatOrig.Id, dimensionStructureNode.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteAsync(sourceFormatOrig)
               .ConfigureAwait(false);

            // Assert
            List<SourceFormat> sourceFormats = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAllAsync()
               .ConfigureAwait(false);
            sourceFormats.Count.Should().Be(0);

            List<DimensionStructureNode> dimensionStructureNodes = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAllDimensionStructureNodesAsync()
               .ConfigureAwait(false);
            dimensionStructureNodes.Count.Should().Be(0);
        }

        [Fact]
        public async Task Deletes_TheFullDimensionStructureNodeTree()
        {
            // Arrange
            SourceFormat sourceFormatOrig = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode root = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormatOrig.Id, root.Id).ConfigureAwait(false);

            DimensionStructureNode oneOnFirstLevel = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(oneOnFirstLevel.Id, root.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode secondOnFirstLevel = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(secondOnFirstLevel.Id, root.Id, root.Id)
               .ConfigureAwait(false);

            DimensionStructureNode thirdOnFirstLevel = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(thirdOnFirstLevel.Id, root.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode firstToTheFirst = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(firstToTheFirst.Id, oneOnFirstLevel.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode secondToTheFirst = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(secondToTheFirst.Id, oneOnFirstLevel.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode firstToTheSecond = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(firstToTheSecond.Id, secondOnFirstLevel.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode secondToTheSecond = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(secondToTheSecond.Id, secondOnFirstLevel.Id,
                    sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode firstToTheThird = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(firstToTheThird.Id, thirdOnFirstLevel.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            DimensionStructureNode secondToTheThird = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(secondToTheThird.Id, thirdOnFirstLevel.Id, sourceFormatOrig.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .DeleteAsync(sourceFormatOrig)
               .ConfigureAwait(false);

            // Assert
            List<SourceFormat> sourceFormats = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAllAsync()
               .ConfigureAwait(false);
            sourceFormats.Count.Should().Be(0);

            List<DimensionStructureNode> dimensionStructureNodes = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAllDimensionStructureNodesAsync()
               .ConfigureAwait(false);
            dimensionStructureNodes.Count.Should().Be(0);
        }

        public DeleteAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
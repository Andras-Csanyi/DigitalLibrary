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
            SourceFormat sourceFormat = new SourceFormat { Id = 100 };

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
        public async Task CeaseConnection_BetweenSFAndDS_ButDSHasOtherConnections()
        {
        }

        [Fact]
        public async Task Remove_AllDimensionStructureNodesBelongToSourceFormat()
        {
        }

        public DeleteAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
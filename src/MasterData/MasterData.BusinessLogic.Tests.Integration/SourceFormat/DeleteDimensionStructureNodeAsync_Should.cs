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
    public class DeleteDimensionStructureNodeAsyncShould : TestBase
    {
        public DeleteDimensionStructureNodeAsyncShould(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task Throw_WhenToBeDeleted_DoesNotExist()
        {
            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteDimensionStructureNodeFromTreeAsync(10, 11, 112)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        [Fact]
        public async Task Delete_Dsn_FromLevel1()
        {
            // Arrange
            Dictionary<string, long> tree = await CreateThreeLevelDeepAndWideDsnTreeAsync().ConfigureAwait(false);

            long toBeDeleted = tree["dsn-2"];

            DimensionStructureNode parent = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(toBeDeleted)
               .ConfigureAwait(false);

            long sfId = tree["sf"];

            // Act
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteDimensionStructureNodeFromTreeAsync(toBeDeleted, parent.Id, sfId)
               .ConfigureAwait(false);

            // Assert
            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(toBeDeleted)
               .ConfigureAwait(false);
            result.Should().BeNull();

            long dsn_2_1_id = tree["dsn-2-1"];
            DimensionStructureNode dsn_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_1_id)
               .ConfigureAwait(false);
            dsn_2_1_result.Should().BeNull();

            long dsn_2_2_id = tree["dsn-2-2"];
            DimensionStructureNode dsn_2_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_2_id)
               .ConfigureAwait(false);
            dsn_2_2_result.Should().BeNull();

            long dsn_2_3_id = tree["dsn-2-3"];
            DimensionStructureNode dsn_2_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_3_id)
               .ConfigureAwait(false);
            dsn_2_3_result.Should().BeNull();

            long dsn_2_1_1_id = tree["dsn-2-1-1"];
            DimensionStructureNode dsn_2_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_1_1_id)
               .ConfigureAwait(false);
            dsn_2_1_1_result.Should().BeNull();
        }

        [Fact]
        public async Task Delete_Dsn_FromTheBottom()
        {
            // Arrange
            Dictionary<string, long> tree = await CreateThreeLevelDeepAndWideDsnTreeAsync().ConfigureAwait(false);

            long toBeDeleted = tree["dsn-2-3-3"];

            DimensionStructureNode parent = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(toBeDeleted)
               .ConfigureAwait(false);

            long sfId = tree["sf"];

            // Act
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteDimensionStructureNodeFromTreeAsync(toBeDeleted, parent.Id, sfId)
               .ConfigureAwait(false);

            // Assert
            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(toBeDeleted)
               .ConfigureAwait(false);
            result.Should().BeNull();

            long dsn_2_3_id = tree["dsn-2-3"];
            DimensionStructureNode dsn_2_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_3_id)
               .ConfigureAwait(false);
            dsn_2_3_result.Should().NotBeNull();

            long dsn_2_3_1_id = tree["dsn-2-3-1"];
            DimensionStructureNode dsn_2_3_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_3_1_id)
               .ConfigureAwait(false);
            dsn_2_3_1_result.Should().NotBeNull();

            long dsn_2_3_2_id = tree["dsn-2-3-2"];
            DimensionStructureNode dsn_2_3_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAsync(dsn_2_3_2_id)
               .ConfigureAwait(false);
            dsn_2_3_2_result.Should().NotBeNull();
        }
    }
}

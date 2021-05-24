namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
        public async Task Delete_Dsn_WithItsChildren()
        {
            // Arrange
            Random rnd = new Random();
            Dictionary<string, long> tree = await CreateThreeLevelDeepAndWideDsnTreeAsync().ConfigureAwait(false);

            long toBeDeleted = tree.ElementAt(rnd.Next(0, tree.Count - 1)).Value;

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
        }
    }
}

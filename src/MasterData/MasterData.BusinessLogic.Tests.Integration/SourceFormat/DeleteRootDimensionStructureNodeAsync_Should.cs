namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Tests.TestData.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class DeleteRootDimensionStructureNodeAsync_Should : TestBase
    {
        public DeleteRootDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Theory]
        [ClassData(typeof(DeleteRootDimensionStructureNodeAsync_NoSuchEntity))]
        public async Task Throw_WhenNoSuchDimensionStructureNode_Or_SourceFormat(
            long dimensionStructureNodeId,
            bool isDimensionStructureNodeExist,
            long sourceFormatId,
            bool isSourceFormatExist)
        {
            // Arrange
            long dimensionStructureNodeIdUsed;
            long sourceFormatIdUsed;

            if (isDimensionStructureNodeExist)
            {
                DimensionStructureNode dsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
                dimensionStructureNodeIdUsed = dsn.Id;
            }
            else
            {
                dimensionStructureNodeIdUsed = dimensionStructureNodeId;
            }

            if (isSourceFormatExist)
            {
                SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
                sourceFormatIdUsed = sf.Id;
            }
            else
            {
                sourceFormatIdUsed = sourceFormatId;
            }

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteRootDimensionStructureNodeAsync(dimensionStructureNodeIdUsed, sourceFormatIdUsed)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        [Fact]
        public async Task Throw_WhenBothDsnAndSfHaveConnection_ButToSomewhereElse()
        {
            // Arrange
            SourceFormat sf1 = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode dsn1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf1.Id, dsn1.Id)
               .ConfigureAwait(false);

            SourceFormat sf2 = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode dsn2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf2.Id, dsn2.Id)
               .ConfigureAwait(false);

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteRootDimensionStructureNodeAsync(dsn1.Id, sf2.Id)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}

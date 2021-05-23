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

        [Fact]
        public async Task DeleteRootDsn_WhenItDoesNotHaveChildren()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, rootDsn.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteRootDimensionStructureNodeAsync(rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(sourceFormat)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.Should().BeNull();

            int dsnAmount = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);
            dsnAmount.Should().Be(0);
        }

        [Fact]
        public async Task DeleteRootDsn_WithItsChildren_WhenItHasOnlyOne()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, rootDsn.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteRootDimensionStructureNodeAsync(rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(sourceFormat)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.Should().BeNull();

            int dsnAmount = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);
            dsnAmount.Should().Be(0);
        }

        [Fact]
        public async Task DeleteRootDsn_WithItsChildren_WhenItHasTwo()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, rootDsn.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_2.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteRootDimensionStructureNodeAsync(rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(sourceFormat)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.Should().BeNull();

            int dsnAmount = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);
            dsnAmount.Should().Be(0);
        }

        [Fact]
        public async Task DeleteRootDsn_WithItsChildren_WhenItHasThree()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, rootDsn.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_2.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteRootDimensionStructureNodeAsync(rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(sourceFormat)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.Should().BeNull();

            int dsnAmount = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);
            dsnAmount.Should().Be(0);
        }

        [Fact]
        public async Task DeleteRootDsn_WithItsChildren_WhenItHasAFullTree()
        {
            // Arrange
            SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sourceFormat.Id, rootDsn.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, dsn_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, dsn_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_3.Id, dsn_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_2.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3.Id, rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3_1.Id, dsn_3.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3_2.Id, dsn_3.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3_3.Id, dsn_3.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3_1_1.Id, dsn_3_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3_1_2 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3_1_2.Id, dsn_3_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_3_1_3 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_3_1_3.Id, dsn_3_1.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .DeleteRootDimensionStructureNodeAsync(rootDsn.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(sourceFormat)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.Should().BeNull();

            int dsnAmount = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);
            dsnAmount.Should().Be(0);
        }
    }
}

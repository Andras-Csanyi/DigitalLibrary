namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AppendDimensionStructureNodeAsync_Should : TestBase
    {
        public AppendDimensionStructureNodeAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task Add_ChildNode_ToNodeAtFirstLevelBelowRDN()
        {
            /*
              * SF
              * -> root dsn
              *    -> level 1 - 1
              *       -> level 1 - 1 - 1
              */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 =
                await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(3);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);
        }

        [Fact]
        public async Task Add_FirstChildNode_ToTheSecondChildOfRootDns()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             *       -> level 1 - 1 - 1
             *       -> level 1 - 1 - 2
             *       -> level 1 - 1 - 3
             *    -> level 1 - 2
             *      -> level 1 - 2 - 1
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_1.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(7);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_2_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_1.Id)
               .ConfigureAwait(false);
            dsn_1_2_1_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_1_result.ParentNode.Id.Should().Be(dsn_1_2.Id);
        }

        [Fact]
        public async Task Add_SecondChildNode_ToTheSecondChildOfRootDns()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             *       -> level 1 - 1 - 1
             *       -> level 1 - 1 - 2
             *       -> level 1 - 1 - 3
             *    -> level 1 - 2
             *      -> level 1 - 2 - 1
             *      -> level 1 - 2 - 2
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_1.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_2.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(8);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_2_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_1.Id)
               .ConfigureAwait(false);
            dsn_1_2_1_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_1_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_2_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_2_result.ParentNode.Id.Should().Be(dsn_1_2.Id);
        }

        [Fact]
        public async Task Add_ThirdChildNode_ToTheSecondChildOfRootDns()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             *       -> level 1 - 1 - 1
             *       -> level 1 - 1 - 2
             *       -> level 1 - 1 - 3
             *    -> level 1 - 2
             *      -> level 1 - 2 - 1
             *      -> level 1 - 2 - 2
             *      -> level 1 - 2 - 3
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_1.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_2.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_3.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(9);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_2_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_1.Id)
               .ConfigureAwait(false);
            dsn_1_2_1_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_1_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_2_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_2_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_3.Id)
               .ConfigureAwait(false);
            dsn_1_2_3_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_3_result.ParentNode.Id.Should().Be(dsn_1_2.Id);
        }

        [Fact]
        public async Task Add_FirstChildNode_ToTheThirdChildOfRootDns()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             *       -> level 1 - 1 - 1
             *       -> level 1 - 1 - 2
             *       -> level 1 - 1 - 3
             *    -> level 1 - 2
             *      -> level 1 - 2 - 1
             *      -> level 1 - 2 - 2
             *      -> level 1 - 2 - 3
             *    -> level 1 - 3
             *      -> level 1 - 3 - 1
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_1.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_2.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_3.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3.Id,
                    rootDsn.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3_1 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3_1.Id,
                    dsn_1_3.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(11);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_2_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_1.Id)
               .ConfigureAwait(false);
            dsn_1_2_1_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_1_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_2_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_2_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_3.Id)
               .ConfigureAwait(false);
            dsn_1_2_3_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_3_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_3_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_3_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_3_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3_1.Id)
               .ConfigureAwait(false);
            dsn_1_3_1_result.ParentNodeId.Should().Be(dsn_1_3.Id);
            dsn_1_3_1_result.ParentNode.Id.Should().Be(dsn_1_3.Id);
        }

        [Fact]
        public async Task Add_SecondChildNode_ToTheThirdChildOfRootDns()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             *       -> level 1 - 1 - 1
             *       -> level 1 - 1 - 2
             *       -> level 1 - 1 - 3
             *    -> level 1 - 2
             *      -> level 1 - 2 - 1
             *      -> level 1 - 2 - 2
             *      -> level 1 - 2 - 3
             *    -> level 1 - 3
             *      -> level 1 - 3 - 1
             *      -> level 1 - 3 - 2
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_1.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_2.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_3.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3.Id,
                    rootDsn.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3_1 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3_1.Id,
                    dsn_1_3.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3_2.Id,
                    dsn_1_3.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(12);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_2_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_1.Id)
               .ConfigureAwait(false);
            dsn_1_2_1_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_1_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_2_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_2_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_3.Id)
               .ConfigureAwait(false);
            dsn_1_2_3_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_3_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_3_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_3_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_3_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3_1.Id)
               .ConfigureAwait(false);
            dsn_1_3_1_result.ParentNodeId.Should().Be(dsn_1_3.Id);
            dsn_1_3_1_result.ParentNode.Id.Should().Be(dsn_1_3.Id);

            DimensionStructureNode dsn_1_3_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3_2.Id)
               .ConfigureAwait(false);
            dsn_1_3_2_result.ParentNodeId.Should().Be(dsn_1_3.Id);
            dsn_1_3_2_result.ParentNode.Id.Should().Be(dsn_1_3.Id);
        }

        [Fact]
        public async Task Add_ThirdChildNode_ToTheThirdChildOfRootDns()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             *       -> level 1 - 1 - 1
             *       -> level 1 - 1 - 2
             *       -> level 1 - 1 - 3
             *    -> level 1 - 2
             *      -> level 1 - 2 - 1
             *      -> level 1 - 2 - 2
             *      -> level 1 - 2 - 3
             *    -> level 1 - 3
             *      -> level 1 - 3 - 1
             *      -> level 1 - 3 - 2
             *      -> level 1 - 3 - 3
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_2.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_1.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_2.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_2_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_2_3.Id,
                    dsn_1_2.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3.Id,
                    rootDsn.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3_1 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3_1.Id,
                    dsn_1_3.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3_2 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3_2.Id,
                    dsn_1_3.Id,
                    sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_3_3 =
                await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    dsn_1_3_3.Id,
                    dsn_1_3.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(13);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_2_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_2_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_1.Id)
               .ConfigureAwait(false);
            dsn_1_2_1_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_1_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_2.Id)
               .ConfigureAwait(false);
            dsn_1_2_2_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_2_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_2_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_2_3.Id)
               .ConfigureAwait(false);
            dsn_1_2_3_result.ParentNodeId.Should().Be(dsn_1_2.Id);
            dsn_1_2_3_result.ParentNode.Id.Should().Be(dsn_1_2.Id);

            DimensionStructureNode dsn_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_3_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_3_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_3_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3_1.Id)
               .ConfigureAwait(false);
            dsn_1_3_1_result.ParentNodeId.Should().Be(dsn_1_3.Id);
            dsn_1_3_1_result.ParentNode.Id.Should().Be(dsn_1_3.Id);

            DimensionStructureNode dsn_1_3_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3_2.Id)
               .ConfigureAwait(false);
            dsn_1_3_2_result.ParentNodeId.Should().Be(dsn_1_3.Id);
            dsn_1_3_2_result.ParentNode.Id.Should().Be(dsn_1_3.Id);

            DimensionStructureNode dsn_1_3_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_3_3.Id)
               .ConfigureAwait(false);
            dsn_1_3_3_result.ParentNodeId.Should().Be(dsn_1_3.Id);
            dsn_1_3_3_result.ParentNode.Id.Should().Be(dsn_1_3.Id);
        }

        [Fact]
        public async Task Add_SecondChildNode_ToNodeAtFirstLevelBelowRDN()
        {
            /*
            * SF
            * -> root dsn
            *    -> level 1 - 1
            *       -> level 1 - 1 - 1
             *      -> level 1 - 1 - 2
            */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDns = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDns.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1 =
                await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1.Id, rootDns.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1_1.Id, dsn_level_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1_2.Id, dsn_level_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(4);

            DimensionStructureNode secondChildOfFirstLevel = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_level_1_1_2.Id)
               .ConfigureAwait(false);
            secondChildOfFirstLevel.ParentNodeId.Should().Be(dsn_level_1_1.Id);
        }

        [Fact]
        public async Task Add_ThirdChildNode_ToNodeAtFirstLevelBelowRDN()
        {
            /*
            * SF
            * -> root dsn
            *    -> level 1 - 1
            *       -> level 1 - 1 - 1
            *       -> level 1 - 1 - 2
            *       -> level 1 - 1 - 3
            */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 =
                await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_1 =
                await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_1.Id, dsn_1_1.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_2.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1_3.Id, dsn_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(5);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);

            DimensionStructureNode dsn_1_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_1_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_1_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_2_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_2.Id)
               .ConfigureAwait(false);
            dsn_1_1_2_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_2_result.ParentNode.Id.Should().Be(dsn_1_1.Id);

            DimensionStructureNode dsn_1_1_3_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1_3.Id)
               .ConfigureAwait(false);
            dsn_1_1_3_result.ParentNodeId.Should().Be(dsn_1_1.Id);
            dsn_1_1_3_result.ParentNode.Id.Should().Be(dsn_1_1.Id);
        }

        [Fact]
        public async Task Append_ChildNode_ToRootDsn()
        {
            /*
             * SF
             * -> root dsn
             *    -> level 1 - 1
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(2);

            DimensionStructureNode dsn_1_1_result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_1_1.Id)
               .ConfigureAwait(false);
            dsn_1_1_result.ParentNodeId.Should().Be(rootDsn.Id);
            dsn_1_1_result.ParentNode.Id.Should().Be(rootDsn.Id);
        }
    }
}

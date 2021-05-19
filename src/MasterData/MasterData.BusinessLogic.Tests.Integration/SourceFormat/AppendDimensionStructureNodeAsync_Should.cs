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
            DimensionStructureNode rootDns = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDns.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1 =
                await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1.Id, rootDns.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1_1.Id, dsn_level_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(3);

            DimensionStructureNode firstChildOfFirstLevel = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_level_1_1_1.Id)
               .ConfigureAwait(false);
            firstChildOfFirstLevel.ParentNodeId.Should().Be(dsn_level_1_1.Id);
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
             */
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id).ConfigureAwait(false);

            DimensionStructureNode firstLevel = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(firstLevel.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode firstChildOf_FirstLevel = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(firstChildOf_FirstLevel.Id, firstLevel.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode secondChildOf_FirstLevel = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(secondChildOf_FirstLevel.Id, firstLevel.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode thirdChildOf_FirstLevel = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(thirdChildOf_FirstLevel.Id, firstLevel.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode secondLegOfRootDns = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(secondLegOfRootDns.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode firstChild_OfTheSecondLeg_OfRootDns = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(
                    firstChild_OfTheSecondLeg_OfRootDns.Id,
                    secondLegOfRootDns.Id,
                    sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(7);

            DimensionStructureNode thirdChildOfFirstLevel = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(firstChild_OfTheSecondLeg_OfRootDns.Id)
               .ConfigureAwait(false);
            thirdChildOfFirstLevel.ParentNodeId.Should().Be(secondLegOfRootDns.Id);
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

            DimensionStructureNode dsn_level_1_1 =
                await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1.Id, rootDsn.Id, sf.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1_1 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1_1.Id, dsn_level_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1_2 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1_2.Id, dsn_level_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1_3 = await CreateSavedDimensionStructureNodeEntity()
               .ConfigureAwait(false);

            // Act
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1_3.Id, dsn_level_1_1.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            int amountOfDnsOfSf = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);
            amountOfDnsOfSf.Should().Be(5);

            DimensionStructureNode thirdChildOfFirstLevel = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(dsn_level_1_1_3.Id)
               .ConfigureAwait(false);
            thirdChildOfFirstLevel.ParentNodeId.Should().Be(dsn_level_1_1.Id);
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
            DimensionStructureNode root = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, root.Id).ConfigureAwait(false);

            DimensionStructureNode dsn_level_1_1 = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait
                (false);

            // Action
            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(dsn_level_1_1.Id, root.Id, sf.Id)
               .ConfigureAwait(false);

            // Assert
            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureNodeTreeAsync(sf)
               .ConfigureAwait(false);
            result.SourceFormatDimensionStructureNode.DimensionStructureNode.ChildNodes.ElementAt(0).Id
               .Should().Be(dsn_level_1_1.Id);
        }
    }
}
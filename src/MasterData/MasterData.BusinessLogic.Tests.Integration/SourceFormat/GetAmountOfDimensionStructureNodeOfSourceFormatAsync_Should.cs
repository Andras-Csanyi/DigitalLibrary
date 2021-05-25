namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class GetAmountOfDimensionStructureNodeOfSourceFormatAsync_Should : TestBase
    {
        public GetAmountOfDimensionStructureNodeOfSourceFormatAsync_Should(
            ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task Return_Zero_WhenSfDoesNotHaveNodes()
        {
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);

            // Act
            long amount = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);

            // Assert
            amount.Should().Be(0);
        }

        [Fact]
        public async Task Return_One_WhenSfHasOnlyRootDsn()
        {
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id)
               .ConfigureAwait(false);

            // Act
            long amount = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);

            // Assert
            amount.Should().Be(1);
        }

        [Fact]
        public async Task Return_Two_WhenSfHasTwoChildren()
        {
            // Arrange
            SourceFormat sf = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
            DimensionStructureNode rootDsn = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureNodeAsync(sf.Id, rootDsn.Id)
               .ConfigureAwait(false);

            DimensionStructureNode child = await CreateSavedDimensionStructureNodeEntity().ConfigureAwait(false);
            await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AppendDimensionStructureNodeToTreeAsync(child.Id, rootDsn.Id, sf.Id)
               .ConfigureAwait(false);

            // Act
            long amount = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf)
               .ConfigureAwait(false);

            // Assert
            amount.Should().Be(2);
        }
    }
}

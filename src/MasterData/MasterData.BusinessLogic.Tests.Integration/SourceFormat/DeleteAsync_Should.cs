namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    public class DeleteAsync_Should : TestBase
    {
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
        public async Task CeaseConnecttion_BetweenSourceFormatAndDimensionStructure()
        {
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
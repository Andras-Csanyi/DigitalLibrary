namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class GetAllAsync_Should : TestBase
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        public async Task Return_AllEntities(int inactive, int active, int expected)
        {
            // Arrange
            await CreateInactiveAndSavedSourceFormatEntitiesAsync(inactive).ConfigureAwait(false);
            await CreateActiveAndSavedSourceFormatEntitiesAsync(active).ConfigureAwait(false);

            // Action
            List<SourceFormat> result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        public async Task Return_InactiveEntities(int inactive, int active, int expected)
        {
            // Arrange
            await CreateInactiveAndSavedSourceFormatEntitiesAsync(inactive).ConfigureAwait(false);
            await CreateActiveAndSavedSourceFormatEntitiesAsync(active).ConfigureAwait(false);

            // Action
            List<SourceFormat> result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetInActivesAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        public async Task Return_ActiveEntities(int inactive, int active, int expected)
        {
            // Arrange
            await CreateInactiveAndSavedSourceFormatEntitiesAsync(inactive).ConfigureAwait(false);
            await CreateActiveAndSavedSourceFormatEntitiesAsync(active).ConfigureAwait(false);

            // Action
            List<SourceFormat> result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetActivesAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(expected);
        }

        public GetAllAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.TopDimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Count_SourceFormatsAsync_Should : TestBase
    {
        public Count_SourceFormatsAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Count_SourceFormatsAsync_Should);

        [Fact]
        public async Task ReturnsZero_WhenThereAreNoTopDimensionstructures()
        {
            // Arrange

            // Act
            long count = await masterDataBusinessLogic.CountSourceFormatsAsync()
               .ConfigureAwait(false);

            // Assert
            count.Should().Be(0);
        }
    }
}
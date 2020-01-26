namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Count_Should : TestBase
    {
        public Count_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Count_Should);

        [Fact]
        public async Task ReturnsAll()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            SourceFormat result = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat).ConfigureAwait(false);

            SourceFormat sourceFormat2 = new SourceFormat
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 0,
            };

            SourceFormat result2 = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat2).ConfigureAwait(false);

            // Act
            long count = await masterDataBusinessLogic.CountSourceFormatsAsync().ConfigureAwait(false);

            // Arrange
            count.Should().Be(2);
        }

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
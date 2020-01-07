namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class CountTopDimensionStructures_Should : TestBase
    {
        public CountTopDimensionStructures_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(CountTopDimensionStructures_Should);

        [Fact]
        public async Task ReturnsZero_WhenThereAreNoTopDimensionstructures()
        {
            // Arrange

            // Act
            long count = await masterDataBusinessLogic.CountTopDimensionStructuresAsync()
                .ConfigureAwait(false);

            // Assert
            count.Should().Be(0);
        }
    }
}
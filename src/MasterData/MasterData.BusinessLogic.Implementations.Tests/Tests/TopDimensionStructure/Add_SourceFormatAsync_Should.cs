namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.TopDimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Add_SourceFormatAsync_Should : TestBase
    {
        public Add_SourceFormatAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Add_SourceFormatAsync_Should);

        [Fact]
        public async Task Add_ANewSourceFormat()
        {
            // Arrange
            SourceFormat dimensionStructure =
                new SourceFormat
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                };

            // Act
            SourceFormat result = await masterDataBusinessLogic.AddSourceFormatAsync(
                dimensionStructure).ConfigureAwait(false);

            // Arrange
            result.Should().NotBeNull();
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(dimensionStructure.Name);
            result.Desc.Should().Be(dimensionStructure.Desc);
            result.IsActive.Should().Be(dimensionStructure.IsActive);
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddAsync_Should : TestBase
    {
        [Fact]
        public async Task Create_AnEntity()
        {
            // Arrange
            SourceFormat sourceFormatOrig = _sourceFormatFaker.Generate();

            // Action
            SourceFormat sourceFormatResult = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddAsync(sourceFormatOrig)
               .ConfigureAwait(false);

            // Assert
            sourceFormatResult.Id.Should().BeGreaterThan(0);
            sourceFormatResult.Name.Should().Be(sourceFormatOrig.Name);
            sourceFormatResult.Desc.Should().Be(sourceFormatOrig.Desc);
            sourceFormatResult.IsActive.Should().Be(sourceFormatOrig.IsActive);
        }

        public AddAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
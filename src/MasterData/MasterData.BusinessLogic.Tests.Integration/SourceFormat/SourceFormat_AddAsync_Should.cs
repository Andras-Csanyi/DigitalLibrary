namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    public class SourceFormat_AddAsync_Should : TestBase
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

        public SourceFormat_AddAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
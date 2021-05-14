namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Tests.TestData.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class UpdateAsync_Should : TestBase
    {
        [Theory]
        [ClassData(typeof(UpdateAsync_TestData))]
        public async Task Update_SpecifiedEntity(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            SourceFormat orig = _sourceFormatFaker.Generate();
            SourceFormat origResult = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddAsync(orig)
               .ConfigureAwait(false);
            SourceFormat update = new SourceFormat
            {
                Id = origResult.Id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Action
            SourceFormat sourceFormat = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .UpdateAsync(update)
               .ConfigureAwait(false);

            // Assert
            sourceFormat.Id.Should().Be(origResult.Id);
            sourceFormat.Name.Should().Be(update.Name);
            sourceFormat.Desc.Should().Be(update.Desc);
            sourceFormat.IsActive.Should().Be(update.IsActive);
        }

        public UpdateAsync_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
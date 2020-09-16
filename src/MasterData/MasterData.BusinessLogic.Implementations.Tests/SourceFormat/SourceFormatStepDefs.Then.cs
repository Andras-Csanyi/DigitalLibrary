namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Threading.Tasks;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class SourceFormatStepDefs
    {
        [Then(@"the returned SourceFormat is not null")]
        public async Task TheReturnedSourceFormatIsNotNull()
        {
            _sourceFormatResult.Should().NotBeNull();
        }

        [Then(@"the returned SourceFormat's id should not be zero")]
        public async Task TheReturnedSourceFormatsIdShouldNotBeZero()
        {
            _sourceFormatResult.Id.Should().NotBe(0);
        }

        [Then(@"the returned SourceFormat's name equals to the original's name")]
        public async Task TheReturnedSourceFormatsNameEqualstoTheOriginalsName()
        {
            _sourceFormatResult.Name.Should().Be(_sourceFormat.Name);
        }

        [Then(@"the returned SourceFormat's description equals to the original's description")]
        public async Task TheReturnedSourceFormatsDescriptionEqualsToTheOriginalsDescription()
        {
            _sourceFormatResult.Desc.Should().Be(_sourceFormat.Desc);
        }

        [Then(@"the returned SourceFormat's is active value equals to the original's is active value")]
        public async Task TheReturnedSourceFormatsIsActiveValueEqualsToTheOriginalsIsActiveValue()
        {
            _sourceFormatResult.IsActive.Should().Be(_sourceFormat.IsActive);
        }
    }
}
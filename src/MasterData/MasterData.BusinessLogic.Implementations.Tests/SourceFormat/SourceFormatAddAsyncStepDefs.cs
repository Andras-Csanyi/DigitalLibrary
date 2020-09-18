namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    using Xunit.Abstractions;

    [Binding]
    public class SourceFormatAddAsyncStepDefs : MasterDataBusinessLogicFeature
    {
        private SourceFormat _sourceFormat;

        private SourceFormat _sourceFormatResult;

        private DimensionStructure _dimensionStructure;

        protected SourceFormatAddAsyncStepDefs(
            ITestOutputHelper testOutputHelper)
            : base(nameof(SourceFormatAddAsyncStepDefs), testOutputHelper)
        {
        }

        [Given(@"there is a SourceFormat without RootDimensionStructure")]
        public void ThereIsASourceFormatWithoutRootDimensionStructure()
        {
            _sourceFormat = new SourceFormat
            {
                Name = "source format without root dimension structure",
                Desc = "description",
                IsActive = 0,
            };
        }

        [Given(@"there is a DimensionStructure")]
        public void ThereIsADimensionStructure()
        {
            _dimensionStructure = new DimensionStructure
            {
                Name = "dimension structure",
                Desc = "desc",
                IsActive = 1,
            };
        }

        [Given(@"DimensionStructure is RootDimensionStructure of SourceFormat")]
        public void DimensionStructureIsRootDimensionStructureOfSourceFormat()
        {
            _sourceFormat.RootDimensionStructure = _dimensionStructure;
        }

        [When(@"SourceFormat is saved")]
        public void SourceFormatIsSaved()
        {
        }

        [When(@"it returns with the newly added SourceFormat")]
        public async Task ItReturnsWithTheNewlyAddedSourceFormat()
        {
            _sourceFormatResult = await _masterDataBusinessLogic.AddSourceFormatAsync(_sourceFormat)
               .ConfigureAwait(false);
        }

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

        [Then(@"the returned SourceFormat's RootDimensionStructure is not null")]
        public async Task TheReturnedSourceFormatsRootDimensionStructureIsNotNull()
        {
        }

        [Then(@"the returned SourceFormat's RootDimensionStructure Id is not zero")]
        public async Task TheReturnedSourceFormatsRootDimensionStructureIsNotZero()
        {
        }

        [Then(@"the returned SourceFormat's RootDimensionStructure's name equals to original's name")]
        public async Task TheReturnesSourceFormatsRootDimensionStructuresNameEqualsToOriginalsName()
        {
        }

        [Then(@"the returned SourceFormat's RootDimensionStructure's desc equals to original's desc")]
        public async Task TheReturnedSourceFormatsRootDimensionStructuresDescEqualsToOriginalsDesc()
        {
        }

        [Then(@"the returned SourceFormat's RootDimensionStructure's is active equals to original's is active")]
        public async Task TheReturnedSourceFormatsRootDimensionStructuresIsActiveEqualToOriginalsIsActive()
        {
        }
    }
}
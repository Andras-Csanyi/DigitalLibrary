namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;

    using Xunit.Abstractions;

    [Binding]
    public partial class SourceFormatStepDefs : MasterDataBusinessLogicFeature
    {
        private SourceFormat _sourceFormat;
        private SourceFormat _sourceFormatResult;

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

        protected SourceFormatStepDefs(
            ITestOutputHelper testOutputHelper)
            : base(nameof(SourceFormatStepDefs), testOutputHelper)
        {
        }
    }
}
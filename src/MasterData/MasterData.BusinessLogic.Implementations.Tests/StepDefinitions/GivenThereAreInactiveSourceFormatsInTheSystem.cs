namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there are (.*) inactive SourceFormats in the system")]
        public async Task GivenThereAreInactiveSourceFormatsInTheSystem(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                ISourceFormatDomainObject sourceFormatDomainObject = new ThereIsASourceFormatDomainObjectEntity
                {
                    IsActive = 0,
                };
                SourceFormat sourceFormat = _masterDataTestHelper.SourceFormatFactory
                   .Create(sourceFormatDomainObject);
                await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            }
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there are (.*) active SourceFormats in the system")]
        public async Task GivenThereAreActiveSourceFormatsInTheSystem(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                ISourceFormatDomainObject sourceFormatDomainObject = new GivenThereIsASourceFormatDomainObjectEntity
                {
                    IsActive = 1,
                };
                SourceFormat sourceFormat = _masterDataTestHelper.SourceFormatFactory
                   .Create(sourceFormatDomainObject);
                await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddAsync(sourceFormat)
                   .ConfigureAwait(false);
            }
        }
    }
}

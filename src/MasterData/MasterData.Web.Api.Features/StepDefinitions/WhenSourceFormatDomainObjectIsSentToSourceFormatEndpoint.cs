namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat domain object is sent to SourceFormat endpoint")]
        public async Task WhenSourceFormatDomainObjectIsSentToSourceFormatEndpoint(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;

            SourceFormat result = await _masterDataHttpClient
               .SourceFormat
               .AddAsync(sourceFormat)
               .ConfigureAwait(false);
        }
    }
}
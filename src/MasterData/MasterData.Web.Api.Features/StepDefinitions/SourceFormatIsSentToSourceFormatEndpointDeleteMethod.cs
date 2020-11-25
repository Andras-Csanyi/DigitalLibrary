namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is sent to SourceFormat endpoint delete method")]
        public async Task WhenSourceFormatIsSentToSourceFormatEndpointDeleteMethod(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat tobeDeleted = _scenarioContext[instance.Key] as SourceFormat;

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .DeleteAsync(tobeDeleted)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.HttpStatusCode);
        }
    }
}
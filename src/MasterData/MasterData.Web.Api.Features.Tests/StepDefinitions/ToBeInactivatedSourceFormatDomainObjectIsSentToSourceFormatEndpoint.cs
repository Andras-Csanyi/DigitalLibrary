namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"to be inactivated SourceFormat domain object is sent to SourceFormat endpoint")]
        public async Task WhenToBeInactivatedSourceFormatDomainObjectIsSentToSourceFormatEndpoint(Table table)
        {
            Check.IsNotNull(table);

            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat toBeInactivated = _scenarioContext[instance.Key] as SourceFormat;

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .InactivateAsync(toBeInactivated)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.HttpStatusCode);
        }
    }
}
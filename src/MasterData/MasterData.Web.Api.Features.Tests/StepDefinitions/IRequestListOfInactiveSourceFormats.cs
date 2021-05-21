namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I request list of inactive SourceFormats")]
        public async Task WhenIRequestListOfInactiveSourceFormats(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DilibHttpClientResponse<List<SourceFormat>> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .GetInactives()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.Result);
        }
    }
}

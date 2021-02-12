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
        [When(@"I request list of active SourceFormats")]
        public async Task WhenIRequestListOfActiveSourceFormats(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DilibHttpClientResponse<List<SourceFormat>> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .GetActives()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.Result);
        }
    }
}
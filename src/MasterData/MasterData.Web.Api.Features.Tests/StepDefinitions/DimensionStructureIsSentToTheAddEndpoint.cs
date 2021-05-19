namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"DimensionStructure is sent to the Add endpoint")]
        [When(@"DimensionStructure is sent to the Add endpoint")]
        [Then(@"DimensionStructure is sent to the Add endpoint")]
        public async Task GivenDimensionStructureIsSentToTheAddEndpoint(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructure saved = _scenarioContext[instance.Key] as DimensionStructure;

            DilibHttpClientResponse<DimensionStructure> result = await _masterDataHttpClient
               .DimensionStructureHttpClient
               .AddAsync(saved)
               .ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _scenarioContext.Add(instance.ResultKey, result.Result);
            }
            else
            {
                _scenarioContext.Add(instance.ResultKey, result.HttpStatusCode);
            }
        }
    }
}

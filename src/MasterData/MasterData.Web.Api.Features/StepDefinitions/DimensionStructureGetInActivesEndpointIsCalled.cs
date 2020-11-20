namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
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
        [When(@"DimensionStructure GetInActives endpoint is called")]
        public async Task WhenDimensionStructureGetInActivesEndpointIsCalled(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DilibHttpClientResponse<List<DimensionStructure>> result = await _masterDataHttpClient
               .DimensionStructureHttpClient
               .GetInActivesAsync()
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
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
        [When(@"DimensionStructure delete endpoint is called")]
        public async Task WhenDimensionStructureDeleteEndpointIsCalled(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.Key] as DimensionStructure;

            DilibHttpClientResponse<DimensionStructure> result = await _masterDataHttpClient
               .DimensionStructureHttpClient
               .DeleteAsync(dimensionStructure)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.HttpStatusCode);
        }
    }
}
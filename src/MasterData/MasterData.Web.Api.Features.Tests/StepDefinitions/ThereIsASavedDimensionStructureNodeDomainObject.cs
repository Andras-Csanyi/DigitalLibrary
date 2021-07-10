namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a saved DimensionStructureNode domain object")]
        public async Task GivenThereIsASavedDimensionStructureNodeDomainObject(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructureNode node = _dimensionStructureNodeFaker.Generate();

            DilibHttpClientResponse<DimensionStructureNode> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .CreateDimensionStructureNodeAsync(node)
               .ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                throw new Exception(result.ExceptionMessage);
            }

            _scenarioContext.Add(instance.ResultKey, result.Result);
        }
    }
}

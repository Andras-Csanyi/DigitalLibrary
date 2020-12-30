namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using TechTalk.SpecFlow.CommonModels;

    public partial class StepDefinitions
    {
        [When(@"SourceFormatDimensionStructureNode is deleted")]
        public async Task SourceFormatDimensionStructureNodeIsDeleted(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode node = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;

            DilibHttpClientResponse<SourceFormatDimensionStructureNode> result = await _masterDataHttpClient
               .SourceFormatDimensionStructureNodeHttpClient
               .DeleteAsync(node)
               .ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _scenarioContext.Add(instance.ResultKey, 200);
            }
            else
            {
                _scenarioContext.Add(instance.ResultKey, result.HttpStatusCode);
            }
        }
    }
}
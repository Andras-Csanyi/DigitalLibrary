namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"SourceFormatDimensionStructureNode is saved")]
        [When(@"SourceFormatDimensionStructureNode is saved")]
        public async Task WhenSourceFormatDimensionStructureNodeIsSaved(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                _scenarioContext[instance.Key] as SourceFormatDimensionStructureNode;
            Check.IsNotNull(sourceFormatDimensionStructureNode);

            DilibHttpClientResponse<SourceFormatDimensionStructureNode> result =
                await _masterDataHttpClient
                   .SourceFormatDimensionStructureNodeHttpClient
                   .AddAsync(sourceFormatDimensionStructureNode)
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
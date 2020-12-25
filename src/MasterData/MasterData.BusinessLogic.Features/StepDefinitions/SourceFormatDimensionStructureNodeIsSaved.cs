namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

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

            try
            {
                SourceFormatDimensionStructureNode result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .AddAsync(sourceFormatDimensionStructureNode)
                   .ConfigureAwait(false);

                _scenarioContext.Add(instance.ResultKey, result);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}
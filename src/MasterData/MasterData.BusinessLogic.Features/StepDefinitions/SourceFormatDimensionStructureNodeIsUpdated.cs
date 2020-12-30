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
        [When(@"SourceFormatDimensionStructureNode is updated")]
        public async Task WhenSourceFormatDimensionStructureNodeIsUpdated(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode node = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .UpdateAsync(node)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}
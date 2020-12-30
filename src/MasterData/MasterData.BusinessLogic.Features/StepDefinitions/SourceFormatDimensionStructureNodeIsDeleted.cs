namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormatDimensionStructureNode is deleted")]
        public async Task WhenSourceFormatDimensionStructureNodeIsDeleted(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode result = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(result);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .DeleteAsync(result)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, FAIL);
            }
        }
    }
}
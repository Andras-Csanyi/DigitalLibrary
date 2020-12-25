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
        [When(@"SourceFormatDimensionStructureNode is deleted by Id")]
        public async Task WhenSourceFormatDimensionStructureNodeIsDeletedById(Table table)
        {
            IdParamResultKeyEntity instance = table.CreateInstance<IdParamResultKeyEntity>();

            SourceFormatDimensionStructureNode node = new SourceFormatDimensionStructureNode
            {
                Id = Convert.ToInt32(instance.Id),
            };

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .DeleteAsync(node)
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
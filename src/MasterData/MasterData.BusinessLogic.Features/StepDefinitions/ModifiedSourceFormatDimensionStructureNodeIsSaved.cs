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
        [Given(@"modified SourceFormatDimensionStructureNode is saved")]
        public async Task GivenModifiedSourceFormatDimensionStructureNodeIsSaved(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode node = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(node);

            try
            {
                SourceFormatDimensionStructureNode result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .UpdateAsync(node)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, result);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, FAIL);
            }
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode is requested")]
        public async Task ThenSourceFormatDimensionStructureNodeIsRequested(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode requested = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(requested);

            SourceFormatDimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
               .GetByIdAsync(requested)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode is requested")]
        public async Task ThenDimensionStructureNodeIsRequested(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.Key] as DimensionStructureNode;
            Check.IsNotNull(dimensionStructureNode);

            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureNodeBusinessLogic
               .GetByIdAsync(dimensionStructureNode.Id)
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
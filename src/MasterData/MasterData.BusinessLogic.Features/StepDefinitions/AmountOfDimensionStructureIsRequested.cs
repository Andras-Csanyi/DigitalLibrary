namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"amount of active DimensionStructure is requested")]
        public async Task AmountOfDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            int count = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .GetActiveCountAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, count);
        }
    }
}
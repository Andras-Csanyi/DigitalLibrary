namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query active DimensionStructures")]
        public async Task WhenIQueryActiveDimensionStructures(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetActivesAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
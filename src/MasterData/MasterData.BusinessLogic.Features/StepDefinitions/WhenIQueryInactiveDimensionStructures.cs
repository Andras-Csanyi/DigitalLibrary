namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query inactive DimensionStructures")]
        public async Task WhenIQueryInactiveDimensionStructures(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetInactivesAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
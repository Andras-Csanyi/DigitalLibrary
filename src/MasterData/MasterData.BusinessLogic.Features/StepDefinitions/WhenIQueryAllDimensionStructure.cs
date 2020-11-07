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
        [When(@"I query all DimensionStructures")]
        public async Task WhenIQueryAllDimensionStructures(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            List<DimensionStructure> dimensionStructures = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetAllAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, dimensionStructures);
        }
    }
}
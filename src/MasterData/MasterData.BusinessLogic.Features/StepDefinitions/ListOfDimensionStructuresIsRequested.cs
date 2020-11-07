namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"list of DimensionStructures is requested")]
        public async Task ListOfDimensionStructuresIsRequested(Table table)
        {
            Check.IsNotNull(table);
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructuresAsync()
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
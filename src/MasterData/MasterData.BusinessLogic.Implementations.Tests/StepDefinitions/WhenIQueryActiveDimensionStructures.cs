namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query active DimensionStructures")]
        public async Task WhenIQueryActiveDimensionStructures(Table table)
        {
            WhenIQueryActiveDimensionStructuresEntity instance = table
               .CreateInstance<WhenIQueryActiveDimensionStructuresEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetActivesAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    internal class WhenIQueryActiveDimensionStructuresEntity
    {
        public string ResultKey { get; set; }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query all DimensionStructures")]
        public async Task WhenIQueryAllDimensionStructures(Table table)
        {
            WhenIQueryAllDimensionStructureEntity instance = table
               .CreateInstance<WhenIQueryAllDimensionStructureEntity>();

            List<DimensionStructure> dimensionStructures = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetAllAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, dimensionStructures);
        }
    }

    internal class WhenIQueryAllDimensionStructureEntity
    {
        public string ResultKey { get; set; }
    }
}
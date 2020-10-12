namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefs
    {
        [When(@"DimensionStructure is requested")]
        public async Task GivenDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(string key, string resultKey)>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.key] as DimensionStructure;

            try
            {
                DimensionStructure dimensionStructureResult = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetDimensionStructureByIdAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.resultKey, dimensionStructureResult);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.resultKey, e);
            }
        }
    }
}
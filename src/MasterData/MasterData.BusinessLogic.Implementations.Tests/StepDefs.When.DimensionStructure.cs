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

        [When(@"deleting DimensionStructure")]
        public async Task DeletingDimensionStructure(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<(long id, string resultKey)>();

            try
            {
                DimensionStructure dimensionStructure = new DimensionStructure
                {
                    Id = instance.id,
                };
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .DeleteDimensionStructureAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.resultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.resultKey, e);
            }
        }
    }
}
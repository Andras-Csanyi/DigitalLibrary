namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
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

        [When(@"DimensionStructure is logically deleted")]
        public async Task DimensionStructureIsLogicallyDeleted(Table table)
        {
            Check.IsNotNull(table);
            GenericEntity instance = table.CreateInstance<GenericEntity>();

            DimensionStructure toBeDeleted = _scenarioContext[instance.Key] as DimensionStructure;

            try
            {
                DimensionStructure dimensionStructure = new DimensionStructure
                {
                    Id = toBeDeleted.Id,
                };
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .DeleteLogicallyAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }

        [When(@"list of DimensionStructures is requested")]
        public async Task ListOfDimensionStructuresIsRequested(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<GenericEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructuresAsync()
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }

        [When(@"list of active DimensionStructures is requested")]
        public async Task ListOfActiveDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<GenericEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetActivesListAsync()
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }

        [When(@"amount of active DimensionStructure is requested")]
        public async Task AmountOfDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<GenericEntity>();

            int count = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .GetActiveCountAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, count);
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"DimensionStructure is requested")]
        [When(@"DimensionStructure is requested")]
        [Then(@"DimensionStructure is requested")]
        public async Task DimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);

            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.Key] as DimensionStructure;

            try
            {
                DimensionStructure dimensionStructureResult = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetByIdAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, dimensionStructureResult);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}
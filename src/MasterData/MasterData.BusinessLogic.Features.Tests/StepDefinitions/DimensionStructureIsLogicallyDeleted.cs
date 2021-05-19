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
        [When(@"DimensionStructure is logically deleted")]
        public async Task DimensionStructureIsLogicallyDeleted(Table table)
        {
            Check.IsNotNull(table);
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructure toBeDeleted = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(toBeDeleted);

            try
            {
                DimensionStructure dimensionStructure = new DimensionStructure
                {
                    Id = toBeDeleted.Id,
                };
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .InactivateAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}

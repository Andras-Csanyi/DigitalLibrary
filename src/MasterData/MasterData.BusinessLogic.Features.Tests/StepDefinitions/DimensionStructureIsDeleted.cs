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
        [When(@"DimensionStructure is deleted")]
        public async Task WhenDimensionStructureIsDeleted(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructure tobeDeleted = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(tobeDeleted);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .DeleteAsync(tobeDeleted)
                   .ConfigureAwait(false);
                _scenarioContext.Remove(instance.ResultKey);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Remove(instance.ResultKey);
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}
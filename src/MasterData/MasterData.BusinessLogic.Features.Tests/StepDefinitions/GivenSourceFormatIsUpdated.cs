namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"given SourceFormat is updated")]
        [Given(@"given SourceFormat is updated")]
        public async Task WhenGivenSourceFormatIsUpdated(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat payload = _scenarioContext[instance.Key] as SourceFormat;

            try
            {
                SourceFormat result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .UpdateAsync(payload)
                   .ConfigureAwait(false);

                _scenarioContext.Add(instance.ResultKey, result);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}

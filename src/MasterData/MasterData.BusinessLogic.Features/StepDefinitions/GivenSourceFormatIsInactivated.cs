namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
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
        [Given(@"SourceFormat is inactivated")]
        [When(@"SourceFormat is inactivated")]
        public async Task GivenSourceFormatIsInactivated(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat toBeInactivated = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(toBeInactivated);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .InactivateAsync(toBeInactivated)
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
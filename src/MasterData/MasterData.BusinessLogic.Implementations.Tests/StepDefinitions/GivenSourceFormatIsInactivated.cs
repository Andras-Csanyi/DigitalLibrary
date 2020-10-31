namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"SourceFormat is inactivated")]
        public async Task GivenSourceFormatIsInactivated(Table table)
        {
            GivenSourceFormatIsInactivatedEntity instance = table
               .CreateInstance<GivenSourceFormatIsInactivatedEntity>();

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

    internal class GivenSourceFormatIsInactivatedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}
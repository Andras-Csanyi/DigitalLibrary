namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using Gherkin.Events.Args.Attachment;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is deleted")]
        public async Task WhenSourceFormatIsDeleted(Table table)
        {
            WhenSourceFormatIsDeletedEntity instance = table
               .CreateInstance<WhenSourceFormatIsDeletedEntity>();

            SourceFormat target = _scenarioContext[instance.Key] as SourceFormat;

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteAsync(target)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }

    internal class WhenSourceFormatIsDeletedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}
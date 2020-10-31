namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query inactive SourceFormats")]
        public async Task WhenIQueryInactiveSourceFormats(Table table)
        {
            WhenIQueryInactiveSourceFormatsEntity instance = table
               .CreateInstance<WhenIQueryInactiveSourceFormatsEntity>();

            List<SourceFormat> result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetInActives()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    internal class WhenIQueryInactiveSourceFormatsEntity
    {
        public string ResultKey { get; set; }
    }
}
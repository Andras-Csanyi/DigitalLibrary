namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query list of SourceFormats")]
        public async Task WhenIQueryListOfSourceFormats(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            List<SourceFormat> result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatsAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
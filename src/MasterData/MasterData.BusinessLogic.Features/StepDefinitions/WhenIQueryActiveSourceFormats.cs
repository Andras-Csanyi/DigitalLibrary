namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"I query active SourceFormats")]
        public async Task WhenIQueryActiveSourceFormats(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            List<SourceFormat> actives = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetActivesAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, actives);
        }
    }
}
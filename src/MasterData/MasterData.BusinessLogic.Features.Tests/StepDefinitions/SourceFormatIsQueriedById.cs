namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is queried by id")]
        public async Task WhenSourceFormatIsQueriedById(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat before = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(before);

            SourceFormat byId = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetByIdAsync(before)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, byId);
        }
    }
}

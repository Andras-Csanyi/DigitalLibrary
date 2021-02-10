namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is requested with DimensionStructureNode tree")]
        public async Task WhenSourceFormatIsRequestedWithDimensionStructureNodeTree(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;

            SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureNodeTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
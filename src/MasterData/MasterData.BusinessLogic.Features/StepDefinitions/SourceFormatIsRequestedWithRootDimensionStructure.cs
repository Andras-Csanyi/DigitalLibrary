namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is requested with root DimensionStructure")]
        public async Task SourceFormatIsRequestedWithRootDimensionStructure(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DomainModel.SourceFormat withoutTree = _scenarioContext[instance.Key] as SourceFormat;

            DomainModel.SourceFormat requestedWithTree = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureAsync(withoutTree)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, requestedWithTree);
        }
    }
}
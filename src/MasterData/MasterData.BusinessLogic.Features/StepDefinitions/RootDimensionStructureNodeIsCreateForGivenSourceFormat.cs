namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"root DimensionStructureNode is create for given SourceFormat")]
        public async Task WhenRootDimensionStructureNodeIsCreateForGivenSourceFormat(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();
            
            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureNodeBusinessLogic
               .CreateRootNodeAsync(sourceFormat)
               .ConfigureAwait(false);
        }
    }
}
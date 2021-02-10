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
        [Given(@"root DimensionStructureNode is created for given SourceFormat")]
        [When(@"root DimensionStructureNode is created for given SourceFormat")]
        public async Task WhenRootDimensionStructureNodeIsCreatedForGivenSourceFormat(Table table)
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
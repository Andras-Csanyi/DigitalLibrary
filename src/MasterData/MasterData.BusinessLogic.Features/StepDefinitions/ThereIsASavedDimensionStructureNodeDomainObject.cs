namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a saved DimensionStructureNode domain object")]
        public async Task GivenThereIsASavedDimensionStructureNodeDomainObject(Table table)
        {
            ThereIsADimensionStructureNodeDomainObjectEntity instance = table
               .CreateInstance<ThereIsADimensionStructureNodeDomainObjectEntity>();

            DimensionStructureNode node = new DimensionStructureNode
            {
                IsActive = instance.IsActive,
            };

            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureNodeBusinessLogic
               .AddAsync(node)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"I have (.*) active saved DimensionStructures")]
        public async Task IHaveGivenAmountActiveSavedDimensionStructures(int activeAmount)
        {
            for (int i = 0; i < activeAmount; i++)
            {
                ThereIsADimensionStructureDomainObjectEntity
                    entity = new ThereIsADimensionStructureDomainObjectEntity
                    {
                        IsActive = 1,
                    };
                DomainModel.DimensionStructure dimensionStructure = _masterDataTestHelper
                   .DimensionStructureFactory
                   .Create(entity);
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
            }
        }
    }
}
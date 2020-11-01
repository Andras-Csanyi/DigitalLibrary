namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"I have (.*) inactive saved DimensionStructures")]
        public async Task IHaveGivenAmountInactiveSavedDimensionStructures(int inactiveAmount)
        {
            for (int i = 0; i < inactiveAmount; i++)
            {
                ThereIsADimensionStructureDomainObjectEntity
                    entity = new ThereIsADimensionStructureDomainObjectEntity
                    {
                        IsActive = 0,
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
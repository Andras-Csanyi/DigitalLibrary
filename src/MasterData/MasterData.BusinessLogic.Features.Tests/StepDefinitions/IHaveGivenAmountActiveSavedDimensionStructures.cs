namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "tmp")]
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
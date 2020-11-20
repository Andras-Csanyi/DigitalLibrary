namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there are (.*) inactive saved DimensionStructures")]
        public async Task GivenThereAreInactiveSavedDimensionStructures(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                IDimensionStructureDomainObject dimensionStructureDomainObject =
                    new GivenThereIsADimensionStructureDomainObject
                    {
                        IsActive = 0,
                    };

                DimensionStructure dimensionStructure = _masterDataTestHelper
                   .DimensionStructureFactory
                   .Create(dimensionStructureDomainObject);

                DilibHttpClientResponse<DimensionStructure> result = await _masterDataHttpClient
                   .DimensionStructureHttpClient
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
            }
        }
    }
}
namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"a DimensionStructure is requested result is")]
        public async Task ThenADimensionStructureIsRequestedResultIs(Table table)
        {
            KeyExpectedValue instance = table.CreateInstance<KeyExpectedValue>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.Key] as DimensionStructure;

            DilibHttpClientResponse<DimensionStructure> result = await _masterDataHttpClient
               .DimensionStructureHttpClient
               .GetByIdAsync(dimensionStructure)
               .ConfigureAwait(false);

            if (result.IsSuccess)
            {
                result.Result.Should().BeNull();
            }
            else
            {
                result.IsSuccess.Should().BeTrue();
            }
        }
    }
}
namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
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
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

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
namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"single SourceFormatDimensionStructureNode item request result is")]
        public void ThenSingleSourceFormatDimensionStructureNodeItemRequestResultIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            DilibHttpClientResponse<SourceFormatDimensionStructureNode> result = _scenarioContext[instance.Key]
                as DilibHttpClientResponse<SourceFormatDimensionStructureNode>;
            Check.IsNotNull(result);

            if (instance.ExpectedValue == "null")
            {
                result.Result.Should().BeNull();
            }
        }
    }
}
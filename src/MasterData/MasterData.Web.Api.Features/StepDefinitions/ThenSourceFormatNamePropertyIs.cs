namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat Name property is '(.*)'")]
        public void ThenSourceFormatNamePropertyIs(string key, string expectedValue)
        {
            Check.IsNotNull(key);
            Check.IsNotNull(expectedValue);

            DilibHttpClientResponse<SourceFormat> result = _scenarioContext[key]
                as DilibHttpClientResponse<SourceFormat>;
            Check.IsNotNull(result);

            result.Result.Name.Should().Be(expectedValue);
        }
    }
}
namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using Io.Cucumber.Messages;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat IsActive property is '(.*)'")]
        public void ThenSourceFormatIsActivePropertyIs(string key, int expectedResult)
        {
            Check.IsNotNull(key);

            DilibHttpClientResponse<SourceFormat> result = _scenarioContext[key]
                as DilibHttpClientResponse<SourceFormat>;
            Check.IsNotNull(result);

            result.Result.IsActive.Should().Be(expectedResult);
        }
    }
}
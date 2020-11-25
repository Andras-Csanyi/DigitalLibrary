namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat IsActive property is '(.*)'")]
        public void ThenSourceFormatIsActivePropertyIs(string key, int expectedResult)
        {
            Check.IsNotNull(key);

            SourceFormat result = _scenarioContext[key] as SourceFormat;
            Check.IsNotNull(result);

            result.IsActive.Should().Be(expectedResult);
        }
    }
}
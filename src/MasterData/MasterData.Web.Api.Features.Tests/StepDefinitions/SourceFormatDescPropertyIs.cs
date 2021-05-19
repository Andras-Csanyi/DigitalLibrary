namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat Desc property is '(.*)'")]
        public void ThenSourceFormatDescPropertyIs(string key, string expectedValue)
        {
            Check.IsNotNull(key);
            Check.IsNotNull(expectedValue);

            SourceFormat result = _scenarioContext[key] as SourceFormat;
            Check.IsNotNull(result);

            result.Desc.Should().Be(expectedValue);
        }
    }
}

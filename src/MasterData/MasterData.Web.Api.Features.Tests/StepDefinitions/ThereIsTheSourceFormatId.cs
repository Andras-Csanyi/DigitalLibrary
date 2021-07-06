namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there is the (.*) SourceFormat Id")]
        public void ThereIsTheSourceFormatId(long sourceFormatId)
        {
            _scenarioContext.Add(ScenarioContextKeys.SourceFormatId, sourceFormatId);
        }
    }
}

namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there is the (.*) value whether SourceFormat exists or not")]
        public void ThereIsTheValueWhetherSourceFormatExistsOrNot(string doesExist)
        {
            bool result = bool.Parse(doesExist);
            _scenarioContext.Add(ScenarioContextKeys.SourceFormatExist, result);
        }
    }
}

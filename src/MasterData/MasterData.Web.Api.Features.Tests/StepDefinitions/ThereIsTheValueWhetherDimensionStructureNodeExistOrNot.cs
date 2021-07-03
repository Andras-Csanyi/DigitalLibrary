namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there is the (.*) value whether DimensionStructureNode exist or not")]
        public void ThereIsTheValueWhetherDimensionStructureNodeExistOrNot(string doesExist)
        {
            bool result = bool.Parse(doesExist.Trim());
            _scenarioContext.Add(ScenarioContextKeys.DimensionStructureNodeIdExist, result);
        }
    }
}

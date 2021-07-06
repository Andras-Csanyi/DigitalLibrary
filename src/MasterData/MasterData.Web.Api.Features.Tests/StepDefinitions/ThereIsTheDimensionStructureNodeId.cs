namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Given(@"there is the (.*) DimensionStructureNode Id")]
        public void ThereIsTheDimensionStructureNodeId(long id)
        {
            _scenarioContext.Add(ScenarioContextKeys.DimensionStructureNodeId, id);
        }
    }
}

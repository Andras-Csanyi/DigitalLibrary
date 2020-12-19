namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.BusinessLogic.Features.SpecflowEntities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode DimensionStructureNodeId is")]
        public void ThenSourceFormatDimensionStructureNodeDimensionStructureNodeIdIs(Table table)
        {
            KeyDimensionStructureNodeKeyEntity instance = table.CreateInstance < ()
        }
    }
}
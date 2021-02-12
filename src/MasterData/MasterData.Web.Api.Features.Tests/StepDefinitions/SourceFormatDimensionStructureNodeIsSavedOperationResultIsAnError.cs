namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode is saved operation result is an error")]
        public void ThenSourceFormatDimensionStructureNodeIsSavedOperationResultIsAnError(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            int result = (int) _scenarioContext[instance.Key];

            result.Should().Be(400);
        }
    }
}
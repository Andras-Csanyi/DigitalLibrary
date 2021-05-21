namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode delete operation result is")]
        public void ThenSourceFormatDimensionStructureNodeDeleteOperationResultIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            string result = _scenarioContext[instance.Key] as string;
            result.Should().Be(instance.ExpectedValue);
        }
    }
}

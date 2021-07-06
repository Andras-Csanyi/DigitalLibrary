namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode delete operation result is an exception")]
        public void ThenSourceFormatDimensionStructureNodeDeleteOperationResultIsAnException(Table table)
        {
            KeyExpectedHttpStatusCodeEntity instance = table.CreateInstance<KeyExpectedHttpStatusCodeEntity>();

            int result = (int)_scenarioContext[instance.Key];
            Check.IsNotNull(result);

            result.Should().Be(instance.ExpectedHttpStatusCode);
        }
    }
}

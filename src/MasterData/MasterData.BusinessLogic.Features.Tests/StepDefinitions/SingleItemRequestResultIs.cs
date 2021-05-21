namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"single item request result is")]
        public void ThenSingleItemRequestResultIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            SourceFormatDimensionStructureNode result = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;

            if (instance.ExpectedValue == null)
            {
                result.Should().BeNull();
            }
        }
    }
}

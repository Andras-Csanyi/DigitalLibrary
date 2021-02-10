namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode DimensionStructureNodeId equals to")]
        public void ThenSourceFormatDimensionStructureNodeDimensionStructureNodeIdEqualsTo(Table table)
        {
            KeyEqualsToEntityLong instance = table.CreateInstance<KeyEqualsToEntityLong>();

            SourceFormatDimensionStructureNode result = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;

            result.DimensionStructureNodeId.Should().Be(instance.EqualsToLong);
        }
    }
}
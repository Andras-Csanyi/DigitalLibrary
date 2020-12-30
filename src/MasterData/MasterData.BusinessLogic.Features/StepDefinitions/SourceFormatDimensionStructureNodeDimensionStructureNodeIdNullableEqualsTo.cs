namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode DimensionStructureNodeId nullable equals to")]
        public void ThenSourceFormatDimensionStructureNodeDimensionStructureNodeIdNullableEqualsTo(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode result =
                _scenarioContext[instance.Key] as SourceFormatDimensionStructureNode;

            result.DimensionStructureNodeId.Should().BeNull();
        }
    }
}
namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode DimensionStructureNodeId is")]
        public void ThenSourceFormatDimensionStructureNodeDimensionStructureNodeIdIs(Table table)
        {
            KeyDimensionStructureNodeKeyEntity instance = table
               .CreateInstance<KeyDimensionStructureNodeKeyEntity>();

            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                _scenarioContext[instance.Key] as SourceFormatDimensionStructureNode;
            Check.IsNotNull(sourceFormatDimensionStructureNode);

            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                as DimensionStructureNode;
            Check.IsNotNull(dimensionStructureNode);

            sourceFormatDimensionStructureNode.DimensionStructureNodeId
               .Should().Be(dimensionStructureNode.Id);
        }
    }
}

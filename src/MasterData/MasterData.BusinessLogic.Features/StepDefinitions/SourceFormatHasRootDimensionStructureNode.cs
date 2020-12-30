namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat has root DimensionStructureNode")]
        public void ThenSourceFormatHasRootDimensionStructureNode(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode
               .Should().NotBeNull();
            sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNodeId
               .Should().NotBe(0);
        }
    }
}
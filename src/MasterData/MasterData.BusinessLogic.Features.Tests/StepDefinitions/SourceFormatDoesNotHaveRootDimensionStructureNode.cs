namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat does not have root DimensionStructureNode")]
        public void SourceFormatDoesNotHaveRootDimensionStructureNode(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();
            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;

            sourceFormat.SourceFormatDimensionStructureNode
               .Should().BeNull();
        }
    }
}
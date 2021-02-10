namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode SourceFormatId nullable equals to")]
        public void ThenSourceFormatDimensionStructureNodeSourceFormatIdNullableEqualsTo(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode result =
                _scenarioContext[instance.Key] as SourceFormatDimensionStructureNode;

            result.SourceFormatId.Should().BeNull();
        }
    }
}
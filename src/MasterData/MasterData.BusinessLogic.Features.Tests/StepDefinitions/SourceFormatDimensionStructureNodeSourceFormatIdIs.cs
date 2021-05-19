namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode SourceFormatId is")]
        public void ThenSourceFormatDimensionStructureNodeSourceFormatIdIs(Table table)
        {
            KeySourceFormatKeyEntity instance = table.CreateInstance<KeySourceFormatKeyEntity>();

            SourceFormatDimensionStructureNode result = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(result);

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey]
                as SourceFormat;
            Check.IsNotNull(sourceFormat);

            result.SourceFormatId.Should().Be(sourceFormat.Id);
        }
    }
}

namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
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

            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                _scenarioContext[instance.Key] as SourceFormatDimensionStructureNode;
            Check.IsNotNull(sourceFormatDimensionStructureNode);

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey]
                as SourceFormat;
            Check.IsNotNull(sourceFormat);

            sourceFormatDimensionStructureNode.SourceFormatId.Should()
               .Be(sourceFormat.Id);
        }
    }
}
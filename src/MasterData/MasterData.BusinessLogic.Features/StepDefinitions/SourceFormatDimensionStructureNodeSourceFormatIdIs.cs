namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.BusinessLogic.Features.SpecflowEntities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

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

            result.SourceFormat.Id.Should().Be(sourceFormat.Id);
            result.SourceFormat.Name.Should().Be(sourceFormat.Name);
            result.SourceFormat.IsActive.Should().Be(sourceFormat.IsActive);
            result.SourceFormat.Guid.Should().Be(sourceFormat.Guid);
            result.SourceFormatId.Should().Be(sourceFormat.Id);
        }
    }
}
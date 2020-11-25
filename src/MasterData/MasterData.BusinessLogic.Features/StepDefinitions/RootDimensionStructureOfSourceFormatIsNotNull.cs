namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"root DimensionStructure of '(.*)' SourceFormat is not null")]
        public void ThenRootDimensionStructureOfSourceFormatIsNotNull(string resultKey)
        {
            Check.NotNullOrEmptyOrWhitespace(resultKey);

            SourceFormat sourceFormat = _scenarioContext[resultKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode
               .Should().NotBeNull();
            sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode
               .DimensionStructure
               .Should().NotBeNull();
        }
    }
}
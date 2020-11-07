namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat result's RootDimensionStructure Id property is not zero")]
        public void SourceFormatResultsRootDimensionStructureIdIsNotZero(string resultKey)
        {
            SourceFormat result = _scenarioContext[resultKey] as SourceFormat;
            Check.IsNotNull(result);

            result.SourceFormatDimensionStructureNode.DimensionStructureNode.Id
               .Should()
               .NotBe(0);
        }
    }
}
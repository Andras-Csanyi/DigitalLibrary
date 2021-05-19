namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat save result is not null")]
        public void SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            SourceFormat result = _scenarioContext[saveResultName] as SourceFormat;
            result.Should().NotBeNull();
        }
    }
}

namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat save result Id is not '(.*)'")]
        public void SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            SourceFormat result = _scenarioContext[saveResultName] as SourceFormat;
            result.Id.Should().NotBe(notEqualsTo);
        }
    }
}
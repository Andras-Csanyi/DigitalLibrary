namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Io.Cucumber.Messages;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat related operation doesn't show error")]
        public void ThenSourceFormatRelatedOperationDoesntShowError(Table table)
        {
            ThenSourceFormatRelatedOperationDoesntShowErrorEntity instance = table
               .CreateInstance<ThenSourceFormatRelatedOperationDoesntShowErrorEntity>();

            string success = _scenarioContext[instance.Key] as string;
            success.Should().Be(SUCCESS);
        }
    }

    internal class ThenSourceFormatRelatedOperationDoesntShowErrorEntity
    {
        public string Key { get; set; }
    }
}
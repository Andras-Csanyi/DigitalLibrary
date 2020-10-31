namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat delete operation doesn't show error")]
        public void ThenSourceFormatDeleteOperationDoesntShowError(Table table)
        {
            ThenSourceFormatDeleteOperationDoesntShowErrorEntity instance = table
               .CreateInstance<ThenSourceFormatDeleteOperationDoesntShowErrorEntity>();

            string result = _scenarioContext[instance.Key] as string;
            result.Should().Be(SUCCESS);
        }
    }

    internal class ThenSourceFormatDeleteOperationDoesntShowErrorEntity
    {
        public string Key { get; set; }
    }
}
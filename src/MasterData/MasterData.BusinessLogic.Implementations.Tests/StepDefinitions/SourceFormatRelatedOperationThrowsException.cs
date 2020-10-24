namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat related operation throws exception")]
        public void SourceFormatRelatedOperationThrowsException(Table table)
        {
            SourceFormatRelatedOperationThrowsExceptionEntity instance = table
               .CreateInstance<SourceFormatRelatedOperationThrowsExceptionEntity>();

            var exception = _scenarioContext[instance.ResultKey];
            exception.Should().BeOfType<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }

    internal class SourceFormatRelatedOperationThrowsExceptionEntity
    {
        public string ResultKey { get; set; }
    }
}
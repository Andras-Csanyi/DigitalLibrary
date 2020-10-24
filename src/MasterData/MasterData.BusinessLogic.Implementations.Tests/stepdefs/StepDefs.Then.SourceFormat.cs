namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.stepdefs
{
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefs
    {
        [Then(@"SourceFormat related operation throws exception")]
        public void SourceFormatRelatedOperationThrowsException(Table table)
        {
            ExceptionWasThrownEntity instance = table.CreateInstance<ExceptionWasThrownEntity>();

            var exception = _scenarioContext[instance.ResultKey];
            exception.Should().BeOfType<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}
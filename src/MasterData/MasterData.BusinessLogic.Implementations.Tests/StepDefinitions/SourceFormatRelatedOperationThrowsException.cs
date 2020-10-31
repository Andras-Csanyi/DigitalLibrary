namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

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

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class SourceFormatRelatedOperationThrowsExceptionEntity
    {
        public string ResultKey { get; set; }
    }
}
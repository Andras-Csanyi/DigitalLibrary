namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat update operation result shows error")]
        public void ThenSourceFormatUpdateOperationResultShowsError(Table table)
        {
            ThenSourceFormatUpdateOperationResultShowsErrorEntity instance = table
               .CreateInstance<ThenSourceFormatUpdateOperationResultShowsErrorEntity>();

            object result = _scenarioContext[instance.Key];

            result.GetType().Should().Be<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ThenSourceFormatUpdateOperationResultShowsErrorEntity
    {
        public string Key { get; set; }
    }
}